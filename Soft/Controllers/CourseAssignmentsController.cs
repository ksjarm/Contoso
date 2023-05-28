using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Facade;
using Contoso.Soft.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Soft.Controllers;
public class CourseAssignmentsController : BaseController<ICourseAssignmentsRepo, CourseAssignment, CourseAssignmentView> {
    private readonly ICoursesRepo courses;
    private readonly IInstructorsRepo instructors;
    public CourseAssignmentsController(
        ICourseAssignmentsRepo r = null, ICoursesRepo c = null, IInstructorsRepo i = null) : base(r) {

        courses = c;
        instructors = i;
    }

    internal const string properties =
        $"{nameof(CourseAssignmentView.ID)}," +
        $"{nameof(CourseAssignmentView.InstructorID)}," +
        $"{nameof(CourseAssignmentView.CourseID)}" +
        $"{nameof(CourseAssignmentView.Description)}," +
        $"{nameof(CourseAssignmentView.ValidFrom)}," +
        $"{nameof(CourseAssignmentView.ValidTo)}";

    [HttpPost, ValidateAntiForgeryToken]
     public async Task<IActionResult> Create([Bind(properties)] CourseAssignmentView v) => await create(toDomain(v));
    
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] CourseAssignmentView v) => await edit(id, toDomain(v));
    protected internal override void relatedLists(CourseAssignment a) {
        ViewBag.Courses = courses?.SelectList;
        ViewBag.Instructors = instructors?.SelectList;
    }
    protected CourseAssignment toDomain(CourseAssignmentView v) => new CourseAssignmentViewFactory().Create(v);
    protected override CourseAssignmentView toView(CourseAssignment o, bool load = false) 
        => new CourseAssignmentViewFactory().Create(o, load);
}