using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;

namespace Contoso.Soft.Controllers;
public class EnrollmentsController : BaseController<IEnrollmentsRepo, Enrollment> {
    private readonly ICoursesRepo courses;
    private readonly IStudentsRepo students;
    public EnrollmentsController(IEnrollmentsRepo r, ICoursesRepo c, IStudentsRepo s) : base(r) {
        courses = c;
        students = s;
    }

    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] Enrollment e) => await create(e);
    
    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] Enrollment e) => await edit(id, e);

	internal const string properties =
        $"{nameof(Enrollment.ID)}," +
        $"{nameof(Enrollment.CourseID)}," +
		$"{nameof(Enrollment.StudentID)}," +
        $"{nameof(Enrollment.Grade)}," +
        $"{nameof(Course.DepartmentID)}";
	protected internal override void relatedLists(Enrollment e = null) {
		ViewBag.Courses = courses.SelectList;
		ViewBag.Students = students.SelectList;
	}
}
