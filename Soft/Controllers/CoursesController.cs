using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contoso.Domain;
using Contoso.Infra;
using Contoso.Domain.Repos;

namespace Contoso.Soft.Controllers;
public class CoursesController : Controller {
    private readonly SchoolContext context;
    private readonly ICoursesRepo repo;
    public CoursesController(SchoolContext c = null, ICoursesRepo r = null) {
        context = c;
        repo = r;
    }
    internal const string properties = $"{nameof(Course.ID)}, {nameof(Course.Number)}, "+
        $"{nameof(Course.Name)}, {nameof(Course.Credits)}, {nameof(Course.DepartmentID)}";
    internal string getPage => nameof(CoursesController).Replace(nameof(Controller), string.Empty);
    public async Task<IActionResult> Index(string sortOrder) {
        ViewData[Pages.Constants.Data.SortOrder] = sortOrder;
        ViewData[Pages.Constants.Data.Page] = getPage;
        return View(await repo.GetAsync(sortOrder));
    }
    public async Task<IActionResult> Details(int? id) => View(await repo.GetAsync(id));
    public IActionResult Create() {
        PopulateDepartmentsDropDownList();
        return View();
    }
    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] Course course) {
        if (ModelState.IsValid) {
            await repo.AddAsync(course);
            return RedirectToAction(nameof(Index));
        }
        PopulateDepartmentsDropDownList(course.DepartmentID);
        return View(course);
    }
    public async Task<IActionResult> Edit(int? id) {
        var course = await repo.GetAsync(id);
        PopulateDepartmentsDropDownList(course.DepartmentID);
        return View(course);
    }
    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] Course course) {
        if (id != course.ID) return NotFound();
        if (ModelState.IsValid) {
            if(await repo.UpdateAsync(course)) return RedirectToAction(nameof(Index));
            else NotFound();
        }
        PopulateDepartmentsDropDownList(course.DepartmentID);
        return View(course);
    }
    private void PopulateDepartmentsDropDownList(object selectedDepartment = null) {
        var departmentsQuery = from d in context.Departments
                               orderby d.Name
                               select d;
        ViewBag.DepartmentID = new SelectList(departmentsQuery.AsNoTracking(), "ID", "Name", selectedDepartment);
    }
    public async Task<IActionResult> Delete(int? id) => View(await repo.GetAsync(id));
    [HttpPost, ActionName(nameof(Delete))] [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
        await repo.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
    private bool CourseExists(int id) => context.Courses.Any(e => e.ID == id);
}
