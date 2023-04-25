using Microsoft.AspNetCore.Mvc;
using Contoso.Domain;
using Contoso.Facade;
using Contoso.Infra;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Soft.Controllers;
public class InstructorsController : BaseController<IInstructorsRepo, Instructor> {
    private readonly SchoolContext context;
    public InstructorsController(SchoolContext c, IInstructorsRepo r = null) : base(r) => context = c;
    
    internal const string properties = 
        $"{nameof(Instructor.ID)}," +
        $"{nameof(Instructor.FirstName)}," +
        $"{nameof(Instructor.Name)}," +
        $"{nameof(Instructor.HireDate)}";
    public async override Task<IActionResult> Index(string sortOrder, int pageIndex, string searchString, int? id, int? relatedId) {
        ViewData[Pages.Constants.Data.SortOrder] = sortOrder;
        ViewData[Pages.Constants.Data.Page] = getPage;
        ViewData[Pages.Constants.Data.PageIndex] = pageIndex;
        ViewData[Pages.Constants.Data.TotalPages] = repo.TotalPages;
        ViewData[Pages.Constants.Data.CurrentFilter] = searchString;
        var viewModel = new InstructorIndexData();
        viewModel.Instructors = await repo.GetAsync(sortOrder, pageIndex, searchString);
        if (id != null) {
            ViewData["InstructorID"] = id.Value;
            Instructor instructor = viewModel.Instructors.Where(i => i.ID == id.Value).FirstOrDefault();
            viewModel.Courses = instructor?.CourseAssignments.Select(s => new Course(s.Course));
        }
        if (relatedId != null) {
            ViewData["CourseID"] = relatedId.Value;
            var selectedCourse = viewModel.Courses?.Where(x => x.ID == relatedId).FirstOrDefault();
            if (selectedCourse != null) { 
                await context.Entry(selectedCourse).Collection(x => x.Enrollments).LoadAsync();
                foreach (Enrollment enrollment in selectedCourse.Enrollments) {
                    await context.Entry(enrollment).Reference(x => x.Student).LoadAsync();
                }
                viewModel.Enrollments = selectedCourse.Enrollments;
            }
        }
        return View(viewModel);
    }
	
	[HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] Instructor i) => await create(i);
    
    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, string[] selectedCourses, [Bind(properties)] Instructor i) {
        if (id != i.ID) return NotFound();
        if (ModelState.IsValid) {
            if (await repo.UpdateAsync(i)) {
                var instructorToUpdate = await context.Instructors
                    .Include(i => i.OfficeAssignment)
                    .Include(i => i.CourseAssignments)
                        .ThenInclude(i => i.Course)
                    .FirstOrDefaultAsync(m => m.ID == id);
                UpdateInstructorCourses(selectedCourses, instructorToUpdate);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else NotFound();
        }
        relatedLists(i);
        return View(i);
    }
	protected internal override void relatedLists(Instructor selectedItem = null) {
		if (selectedItem is null) return;
		var allCourses = context.Courses;
		var instructorCourses = new HashSet<int>(selectedItem.CourseAssignments.Select(c => c.CourseID));
		var viewModel = new List<AssignedCourseData>();
		foreach (var course in allCourses) {
			viewModel.Add(new AssignedCourseData {
				CourseID = course.ID,
				Title = course.Name,
				Assigned = instructorCourses.Contains(course.ID)
			});
		}
		ViewData["Courses"] = viewModel;
	}
	private void UpdateInstructorCourses(string[] selectedCourses, Instructor i) {
		if (i is null) return;
		if (i.CourseAssignments == null) i.CourseAssignments = new List<CourseAssignment>();
        if (selectedCourses == null) {
			i.CourseAssignments = new List<CourseAssignment>();
			return;
		}
		var selectedCoursesHS = new HashSet<string>(selectedCourses);
		var instructorCourses = new HashSet<int> (i.CourseAssignments.Select(c => c.Course.ID));
		foreach (var course in context.Courses) {
			if (selectedCoursesHS.Contains(course.ID.ToString())) {
				if (!instructorCourses.Contains(course.ID)) {
                    i.CourseAssignments.Add(new CourseAssignment { InstructorID = i.ID, CourseID = course.ID });
			    }
            }
			else {
				if (instructorCourses.Contains(course.ID)) {
					CourseAssignment courseToRemove = i.CourseAssignments.FirstOrDefault(i => i.CourseID == course.ID);
					context.Remove(courseToRemove);
				}
			}
		}
	}
}
