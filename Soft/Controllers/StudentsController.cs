using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contoso.Domain;
using Contoso.Infra;
using Contoso.Domain.Repos;

namespace Contoso.Soft.Controllers;

public class StudentsController : Controller {
	private readonly SchoolContext context;
	private readonly IStudentsRepo repo;
	public StudentsController(SchoolContext c, IStudentsRepo r) {
		context = c;
		repo = r;
	}
	public async Task<IActionResult> Index( string sortOrder, string currentFilter, string searchString, int? pageNumber) {
		ViewData["CurrentSort"] = sortOrder;
		ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
		ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
		if (searchString != null) pageNumber = 1; else searchString = currentFilter;
		ViewData["CurrentFilter"] = searchString;
		var students = from s in context.Students select s;
		if (!string.IsNullOrEmpty(searchString))
			students = students.Where(s => s.Name.Contains(searchString) || s.FirstMidName.Contains(searchString));
		switch (sortOrder) {
			case "name_desc":
				students = students.OrderByDescending(s => s.Name);
				break;
			case "Date":
				students = students.OrderBy(s => s.EnrollmentDate);
				break;
			case "date_desc":
				students = students.OrderByDescending(s => s.EnrollmentDate);
				break;
			default:
				students = students.OrderBy(s => s.Name);
				break;
		}
		int pageSize = 3;
		return View(await PaginatedList<Student>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
	}
	public async Task<IActionResult> Details(int? id) {
		if (id == null || context.Students == null) return NotFound();
		var student = await context.Students
			.Include(s => s.Enrollments)
				.ThenInclude(e => e.Course)
			.AsNoTracking()
			.FirstOrDefaultAsync(m => m.ID == id);
		if (student == null) return NotFound();
		return View(student);
	}
	public IActionResult Create() => View();
	[HttpPost] [ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind("EnrollmentDate,FirstMidName,Name")] Student s) {
		await Task.CompletedTask;
		try {
			if (ModelState.IsValid) {
				repo.Add(s);
				return RedirectToAction(nameof(Index));
			}
		} catch (DbUpdateException ex) {
			ModelState.AddModelError("", "Unable to save changes. " +
				"Try again, and if the problem persists " +
				"see your system administrator.");
		}
		return View(s);
	}
	[HttpPost, ActionName("Edit")] [ValidateAntiForgeryToken]
	public async Task<IActionResult> EditPost(int? id) {
		if (id == null) return NotFound();
		var studentToUpdate = await context.Students.FirstOrDefaultAsync(s => s.ID == id);
		if (await TryUpdateModelAsync<Student>(studentToUpdate, "",
			s => s.FirstMidName, s => s.Name, s => s.EnrollmentDate)) {
			try {
				await context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			} catch (DbUpdateException ex) {
				ModelState.AddModelError("", "Unable to save changes. " +
					"Try again, and if the problem persists, " +
					"see your system administrator.");
			}
		}
		return View(studentToUpdate);
	}
	public async Task<IActionResult> Edit(int? id) {
		await Task.CompletedTask;
		var student = repo.Get(id);
		return View(student);
	}
	public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false) {
		await Task.CompletedTask;
		var student = repo.Get(id);
		if (student == null) return NotFound();
		if (saveChangesError.GetValueOrDefault()) {
			ViewData["ErrorMessage"] =
				"Delete failed. Try again, and if the problem persists " +
				"see your system administrator.";
		}
		return View(student);
	}
	[HttpPost, ActionName("Delete")] [ValidateAntiForgeryToken]
	public async Task<IActionResult> DeleteConfirmed(int id) {
		if (context.Students == null) return Problem("Entity set 'SchoolContext.Students'  is null.");
		var student = await context.Students.FindAsync(id);
		if (student == null) return RedirectToAction(nameof(Index));
		try {
			context.Students.Remove(student);
			await context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		} catch (DbUpdateException ex) {
			return RedirectToAction(nameof(Delete), new { id, saveChangesError = true });
		}
	}
	private bool StudentExists(int id) => context.Students.Any(e => e.ID == id);
}
