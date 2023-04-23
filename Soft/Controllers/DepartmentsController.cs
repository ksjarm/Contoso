using Microsoft.AspNetCore.Mvc;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;

namespace Contoso.Soft.Controllers;
public class DepartmentsController : BaseController<IDepartmentsRepo, Department> {
    public DepartmentsController(IDepartmentsRepo r = null) : base(r) { }
    
    internal const string properties = 
        $"{nameof(Department.ID)}," +
        $"{nameof(Department.Name)}," +
        $"{nameof(Department.Budget)}," +
        $"{nameof(Department.StartDate)}," +
        $"{nameof(Department.InstructorID)}";

    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] Department d) => await create(d);

    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] Department c) => await edit(id, c);
}
