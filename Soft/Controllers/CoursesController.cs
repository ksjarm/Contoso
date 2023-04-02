using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contoso.Domain;
using Contoso.Infra;

namespace Contoso.Soft.Controllers;
public class CoursesController : Controller {
    private readonly SchoolContext context;
    public CoursesController(SchoolContext c = null) => context = c;
    public async Task<IActionResult> Index() {
        var courses = context.Courses
            .Include(c => c.Department)
            .AsNoTracking();
        return View(await courses.ToListAsync());
    }
    public async Task<IActionResult> Details(int? id) {
        if (id == null || context.Courses == null) {
            return NotFound();
        }
        var course = await context.Courses
            .Include(c => c.Department)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
        if (course == null) {
            return NotFound();
        }
        return View(course);
    }
    public IActionResult Create() {
        PopulateDepartmentsDropDownList();
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CourseID,Credits,DepartmentID,Title")] Course course) {
        if (ModelState.IsValid) {
            context.Add(course);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        PopulateDepartmentsDropDownList(course.DepartmentID);
        return View(course);
    }
    public async Task<IActionResult> Edit(int? id) {
        if (id == null) {
            return NotFound();
        }
        var course = await context.Courses
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
        if (course == null) {
            return NotFound();
        }
        PopulateDepartmentsDropDownList(course.DepartmentID);
        return View(course);
    }
    [HttpPost, ActionName("Edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditPost(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var courseToUpdate = await context.Courses
            .FirstOrDefaultAsync(c => c.ID == id);

        if (await TryUpdateModelAsync<Course>(courseToUpdate,
            "",
            c => c.Credits, c => c.DepartmentID, c => c.Title))
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            return RedirectToAction(nameof(Index));
        }
        PopulateDepartmentsDropDownList(courseToUpdate.DepartmentID);
        return View(courseToUpdate);
    }
    private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
    {
        var departmentsQuery = from d in context.Departments
                               orderby d.Name
                               select d;
        ViewBag.DepartmentID = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentID", "Name", selectedDepartment);
    }

    // GET: Courses/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || context.Courses == null)
        {
            return NotFound();
        }

        var course = await context.Courses
            .Include(c => c.Department)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
        if (course == null)
        {
            return NotFound();
        }

        return View(course);
    }
    [HttpPost, ActionName("Delete")] [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (context.Courses == null)
        {
            return Problem("Entity set 'SchoolContext.Courses'  is null.");
        }
        var course = await context.Courses.FindAsync(id);
        if (course != null)
        {
            context.Courses.Remove(course);
        }

        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CourseExists(int id)
    {
        return context.Courses.Any(e => e.ID == id);
    }
}
