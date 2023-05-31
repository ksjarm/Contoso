using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Facade;
using Contoso.Soft.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Soft.Controllers;
public class OfficeAssignmentsController : BaseController<IOfficeAssignmentsRepo, OfficeAssignment, OfficeAssignmentView> {
    
    private readonly IInstructorsRepo instructors;
    public OfficeAssignmentsController(IOfficeAssignmentsRepo r = null, IInstructorsRepo i = null) : base(r) => instructors = i;

    internal const string properties =
         $"{nameof(OfficeAssignmentView.ID)}, " +
         $"{nameof(OfficeAssignmentView.ValidFrom)}, " +
         $"{nameof(OfficeAssignmentView.ValidTo)}, " +
         $"{nameof(OfficeAssignmentView.Description)}, " +
         $"{nameof(OfficeAssignmentView.InstructorID)}, " +
         $"{nameof(OfficeAssignmentView.InstructorName)}, " +
         $"{nameof(OfficeAssignmentView.Location)}";
    
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] OfficeAssignmentView v) => await create(toDomain(v));
    
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] OfficeAssignmentView v) => await edit(id, toDomain(v));
    
    protected internal override void relatedLists(OfficeAssignment a) {
        ViewBag.Instructors = instructors?.SelectList;
    }
    protected OfficeAssignment toDomain(OfficeAssignmentView v) => new OfficeAssignmentViewFactory().Create(v);
    protected override OfficeAssignmentView toView(OfficeAssignment o, bool load = false) 
        => new OfficeAssignmentViewFactory().Create(o, load);
}