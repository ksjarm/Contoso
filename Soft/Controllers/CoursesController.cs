using Microsoft.AspNetCore.Mvc;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;
using Contoso.Facade;

namespace Contoso.Soft.Controllers;
public class CoursesController : BaseController<ICoursesRepo, Course, CourseView> {
    private readonly IDepartmentsRepo departments;
    public CoursesController(ICoursesRepo r = null, IDepartmentsRepo d = null) : base(r) => departments = d;

    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] CourseView c) => await create(toDomain(c));
    
    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] CourseView c) => await edit(id, toDomain(c));
    
    internal const string properties =
        $"{nameof(Course.ID)}," +
        $"{nameof(Course.Number)}," +
        $"{nameof(Course.Name)}," +
        $"{nameof(Course.Credits)}," +
        $"{nameof(Course.DepartmentID)}";
    protected internal override void relatedLists(Course selectedItem = null) {
        ViewBag.Departments = departments.SelectList;
    }
    protected override CourseView toView(Course o) => new CourseViewFactory().Create(o);
    protected Course toDomain(CourseView v) => new CourseViewFactory().Create(v);
}
