using Microsoft.AspNetCore.Mvc;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;
using Contoso.Facade;

namespace Contoso.Soft.Controllers;
public class EnrollmentsController : BaseController<IEnrollmentsRepo, Enrollment, EnrollmentView> {
    private readonly ICoursesRepo courses;
    private readonly IStudentsRepo students;
    public EnrollmentsController(IEnrollmentsRepo r = null, ICoursesRepo c = null, IStudentsRepo s = null) : base(r) {
        courses = c;
        students = s;
    }

	internal const string properties =
        $"{nameof(EnrollmentView.ID)}," +
        $"{nameof(EnrollmentView.CourseID)}," +
		$"{nameof(EnrollmentView.StudentID)}," +
        $"{nameof(EnrollmentView.Grade)}," +
        $"{nameof(CourseView.DepartmentID)}";

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] EnrollmentView e) => await create(toDomain(e));

	[HttpPost, ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(int id, [Bind(properties)] EnrollmentView v) => await edit(id, toDomain(v));

	protected internal override void relatedLists(Enrollment e = null) {
		ViewBag.Courses = courses.SelectList;
		ViewBag.Students = students.SelectList;
	}
    protected Enrollment toDomain(EnrollmentView v) => new EnrollmentViewFactory().Create(v);
    protected override EnrollmentView toView(Enrollment v, bool load = false) => new EnrollmentViewFactory().Create(v, load);
}
