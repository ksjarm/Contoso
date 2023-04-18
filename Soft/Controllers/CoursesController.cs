using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contoso.Domain;
using Contoso.Infra;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;

namespace Contoso.Soft.Controllers;
public class CoursesController : SchoolController<ICoursesRepo, Course> {
    public CoursesController(SchoolContext c = null, ICoursesRepo r = null) : base(c, r) { }

    internal const string properties = $"{nameof(Course.ID)}, {nameof(Course.Number)}, "+
        $"{nameof(Course.Name)}, {nameof(Course.Credits)}, {nameof(Course.DepartmentID)}";

    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] Course course) => await create(course);
    
    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] Course course) => await edit(id, course);
    protected internal override void relatedLists(Course selectedItem = null) {
        var departmentsQuery = from d in context.Departments
                               orderby d.Name
                               select d;
        ViewBag.Departments = new SelectList(departmentsQuery.AsNoTracking(), "ID", "Name", selectedItem?.DepartmentID);
    }
    private bool CourseExists(int id) => context.Courses.Any(e => e.ID == id);
}
