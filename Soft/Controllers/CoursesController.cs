using Microsoft.AspNetCore.Mvc;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;
using Contoso.Facade;

namespace Contoso.Soft.Controllers;
public class CoursesController : BaseController<ICoursesRepo, Course, CourseView> {
    private readonly IDepartmentsRepo departments;
    public CoursesController(ICoursesRepo r = null, IDepartmentsRepo d = null) : base(r) => departments = d;
    
    internal const string properties =
        $"{nameof(CourseView.ID)}," +
        $"{nameof(CourseView.Number)}," +
        $"{nameof(CourseView.Name)}," +
        $"{nameof(CourseView.Credits)}," +
        $"{nameof(CourseView.DepartmentID)}";
    
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] CourseView v) => await create(toDomain(v));
    
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] CourseView v) => await edit(id, toDomain(v));

    protected internal override void relatedLists(Course selectedItem = null) {
        ViewBag.Departments = departments.SelectList;
    }
    protected Course toDomain(CourseView v) => new CourseViewFactory().Create(v);
    protected override CourseView toView(Course o, bool load = false) => new CourseViewFactory().Create(o, load);
}
