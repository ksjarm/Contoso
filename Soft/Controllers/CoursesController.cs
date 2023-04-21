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
    public async Task<IActionResult> Create([Bind(properties)] Course c) => await create(c);
    
    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] Course c) => await edit(id, c);
    protected internal override void relatedLists(Course selectedItem = null) {
        ViewBag.Departments = new SelectList(context.Departments.AsNoTracking(), "ID", "Name", selectedItem?.DepartmentID);
    }
}
