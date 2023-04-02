using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contoso.Domain;
using Contoso.Facade;
using Contoso.Infra;
using Contoso.Domain.Repos;

namespace Contoso.Soft.Controllers;

public class InstructorsController : Controller {
	private readonly SchoolContext context;
	private readonly IInstructorsRepo repo;
	public InstructorsController(SchoolContext c, IInstructorsRepo r) {
		context = c;
		repo = r;
	}
	public async Task<IActionResult> Index(int? id, int? courseID) {
		var viewModel = new InstructorIndexData();
		viewModel.Instructors = await context.Instructors
			  .Include(i => i.OfficeAssignment)
			  .Include(i => i.CourseAssignments)
				.ThenInclude(i => i.Course)
					.ThenInclude(i => i.Department)
			  .OrderBy(i => i.LastName)
			  .ToListAsync();
		if (id != null) {
			ViewData["InstructorID"] = id.Value;
			Instructor instructor = viewModel.Instructors.Where(
				i => i.ID == id.Value).Single();
			viewModel.Courses = instructor.CourseAssignments.Select(s => s.Course);
		}
		if (courseID != null) ViewData["CourseID"] = courseID.Value;
		return View(viewModel);
	}
	public async Task<IActionResult> Details(int? id) {
		await Task.CompletedTask;
		var instructor = repo.Get(id);
		return View(instructor);
	}
	public IActionResult Create() {
		var instructor = new Instructor();
		instructor.CourseAssignments = new List<CourseAssignment>();
		PopulateAssignedCourseData(instructor);
		return View();
	}
	[HttpPost] [ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind("FirstMidName,HireDate,LastName,OfficeAssignment")] Instructor i, string[] selectedCourses) {
		await Task.CompletedTask;
		if (selectedCourses != null) {
			i.CourseAssignments = new List<CourseAssignment>();
			foreach (var course in selectedCourses) {
				var courseToAdd = new CourseAssignment { InstructorID = i.ID, CourseID = int.Parse(course) };
				i.CourseAssignments.Add(courseToAdd);
			}
		}
		if (ModelState.IsValid) {
			repo.Add(i);
			return RedirectToAction(nameof(Index));
		}
		PopulateAssignedCourseData(i);
		return View(i);
	}
	public async Task<IActionResult> Edit(int? id) {
		if (id == null || context.Instructors == null) return NotFound();
		var instructor = await context.Instructors
			.Include(i => i.OfficeAssignment)
			.Include(i => i.CourseAssignments).ThenInclude(i => i.Course)
			.AsNoTracking()
			.FirstOrDefaultAsync(m => m.ID == id);
		if (instructor == null) return NotFound();
		PopulateAssignedCourseData(instructor);
		return View(instructor);
	}
	private void PopulateAssignedCourseData(Instructor instructor) {
		var allCourses = context.Courses;
		var instructorCourses = new HashSet<int>(instructor.CourseAssignments.Select(c => c.CourseID));
		var viewModel = new List<AssignedCourseData>();
		foreach (var course in allCourses) {
			viewModel.Add(new AssignedCourseData {
				CourseID = course.ID,
				Title = course.Title,
				Assigned = instructorCourses.Contains(course.ID)
			});
		}
		ViewData["Courses"] = viewModel;
	}
	[HttpPost] [ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(int? id, string[] selectedCourses) {
		if (id == null) return NotFound();
		var instructorToUpdate = await context.Instructors
			.Include(i => i.OfficeAssignment)
			.Include(i => i.CourseAssignments)
		.ThenInclude(i => i.Course)
			.FirstOrDefaultAsync(s => s.ID == id);
		if (await TryUpdateModelAsync<Instructor>( instructorToUpdate, "",
			i => i.FirstMidName, i => i.LastName, i => i.HireDate, i => i.OfficeAssignment)) {
			if (String.IsNullOrWhiteSpace(instructorToUpdate.OfficeAssignment?.Location)) instructorToUpdate.OfficeAssignment = null;
			UpdateInstructorCourses(selectedCourses, instructorToUpdate);
			try {
				await context.SaveChangesAsync();
			} catch (DbUpdateException ex) {
				ModelState.AddModelError("", "Unable to save changes. " +
					"Try again, and if the problem persists, " +
					"see your system administrator.");
			}
			return RedirectToAction(nameof(Index));
		}
		UpdateInstructorCourses(selectedCourses, instructorToUpdate);
		PopulateAssignedCourseData(instructorToUpdate);
		return View(instructorToUpdate);
	}
	private void UpdateInstructorCourses(string[] selectedCourses, Instructor instructorToUpdate) {
		if (selectedCourses == null) {
			instructorToUpdate.CourseAssignments = new List<CourseAssignment>();
			return;
		}
		var selectedCoursesHS = new HashSet<string>(selectedCourses);
		var instructorCourses = new HashSet<int> (instructorToUpdate.CourseAssignments.Select(c => c.Course.ID));
		foreach (var course in context.Courses) {
			if (selectedCoursesHS.Contains(course.ID.ToString())) {
				if (!instructorCourses.Contains(course.ID)) instructorToUpdate.CourseAssignments.Add(new CourseAssignment { InstructorID = instructorToUpdate.ID, CourseID = course.ID });
			}
			else {
				if (instructorCourses.Contains(course.ID)) {
					CourseAssignment courseToRemove = instructorToUpdate.CourseAssignments.FirstOrDefault(i => i.CourseID == course.ID);
					context.Remove(courseToRemove);
				}
			}
		}
	}
	public async Task<IActionResult> Delete(int? id) {
		await Task.CompletedTask;
		var instructor = repo.Get(id);
		return View(instructor);
	}
	[HttpPost, ActionName("Delete")] [ValidateAntiForgeryToken]
	public async Task<IActionResult> DeleteConfirmed(int id) {
		await Task.CompletedTask;
		repo.Delete(id);
		return RedirectToAction(nameof(Index));
	}
	private bool InstructorExists(int id) => context.Instructors.Any(e => e.ID == id);
}
