using Microsoft.AspNetCore.Mvc;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;

namespace Contoso.Soft.Controllers;
public class CoursesController : BaseController<ICoursesRepo, Course> {
    private readonly IDepartmentsRepo departments;
    public CoursesController(ICoursesRepo r, IDepartmentsRepo d) : base(r) => departments = d;

    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] Course c) => await create(c);
    
    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] Course c) => await edit(id, c);
    
    internal const string properties =
        $"{nameof(Course.ID)}," +
        $"{nameof(Course.Number)}," +
        $"{nameof(Course.Name)}," +
        $"{nameof(Course.Credits)}," +
        $"{nameof(Course.DepartmentID)}";
    protected internal override void relatedLists(Course selectedItem = null) {
        ViewBag.Departments = departments.SelectList;
    }
}
