using Microsoft.AspNetCore.Mvc;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;
using Contoso.Facade;

namespace Contoso.Soft.Controllers;
public class DepartmentsController : BaseController<IDepartmentsRepo, Department, DepartmentView> {
    private readonly IInstructorsRepo instructors;
    public DepartmentsController(IDepartmentsRepo r = null, IInstructorsRepo i = null) : base(r) {
        instructors = i;
    }
    
    internal const string properties = 
        $"{nameof(DepartmentView.ID)}," +
        $"{nameof(DepartmentView.Name)}," +
        $"{nameof(DepartmentView.Budget)}," +
        $"{nameof(DepartmentView.StartDate)}," +
        $"{nameof(DepartmentView.InstructorID)}";

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] DepartmentView v) => await create(toDomain(v));

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] DepartmentView v) => await edit(id, toDomain(v));
    
    protected internal override void relatedLists(Department selectedItem = null) {
        ViewBag.Instructors = instructors.SelectList;
    }
    protected Department toDomain(DepartmentView v) => new DepartmentViewFactory().Create(v);
    protected override DepartmentView toView(Department o, bool load = false) => new DepartmentViewFactory().Create(o, load);
}
