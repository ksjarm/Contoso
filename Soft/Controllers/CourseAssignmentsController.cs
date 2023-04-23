using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Soft.Controllers;
public class CourseAssignmentsController : BaseController<ICourseAssignmentsRepo, CourseAssignment>
{
    private readonly ICoursesRepo courses;
    private readonly IInstructorsRepo instructors;

    public CourseAssignmentsController(
        ICourseAssignmentsRepo r = null, ICoursesRepo c = null, IInstructorsRepo i = null) : base(r)
    {

        courses = c;
        instructors = i;
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] CourseAssignment a) => await create(a);

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] CourseAssignment a) => await edit(id, a);

    internal const string properties =
        $"{nameof(CourseAssignment.ID)}," +
        $"{nameof(CourseAssignment.InstructorID)}," +
        $"{nameof(CourseAssignment.CourseID)}";
    protected internal override void relatedLists(CourseAssignment a)
    {
        ViewBag.Courses = courses?.SelectList;
        ViewBag.Instructors = instructors?.SelectList;
    }
}