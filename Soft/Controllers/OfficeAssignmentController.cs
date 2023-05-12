using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Facade;
using Contoso.Infra;
using Contoso.Soft.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Soft.Controllers;
public class OfficeAssignmentsController : BaseController<IOfficeAssignmentsRepo, OfficeAssignment, OfficeAssignmentView> {
    
   private readonly IInstructorsRepo instructors;
    public OfficeAssignmentsController(IOfficeAssignmentsRepo r = null, IInstructorsRepo i = null) : base(r) => instructors = i;
    
    internal const string properties =
         $"{nameof(OfficeAssignmentView.ID)}," +
         $"{nameof(OfficeAssignmentView.InstructorID)}," +
         $"{nameof(OfficeAssignmentView.Location)}," +
         $"{nameof(OfficeAssignmentView.Description)}," +
         $"{nameof(OfficeAssignmentView.ValidFrom)}," +
         $"{nameof(OfficeAssignmentView.ValidTo)}";    
    
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] OfficeAssignmentView a) => await create(toDomain(a));
    
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] OfficeAssignmentView a) => await edit(id, toDomain(a));
    
    protected internal override void relatedLists(OfficeAssignment a) {
        ViewBag.Instructors = instructors?.SelectList;
    }
    protected OfficeAssignment toDomain(OfficeAssignmentView v) => new OfficeAssignmentViewFactory().Create(v);
    protected override OfficeAssignmentView toView(OfficeAssignment o, bool load = false) 
        => new OfficeAssignmentViewFactory().Create(o, load);
}
