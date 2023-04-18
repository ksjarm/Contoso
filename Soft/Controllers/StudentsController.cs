using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contoso.Domain;
using Contoso.Infra;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;
using Contoso.Pages.Constants;

namespace Contoso.Soft.Controllers;

public class StudentsController : SchoolController<IStudentsRepo, Student> {
	public StudentsController(SchoolContext c = null, IStudentsRepo r = null) : base(c, r) { }
    
	internal const string properties = $"{nameof(Student.ID)}, {nameof(Student.EnrollmentDate)}, " +
		$"{nameof(Student.FirstMidName)}, {nameof(Student.Name)}";
 //   public async Task<IActionResult> Details(int? id) {
	//	if (id == null || context.Students == null) return NotFound();
	//	var student = await context.Students
	//		.Include(s => s.Enrollments)
	//			.ThenInclude(e => e.Course)
	//		.AsNoTracking()
	//		.FirstOrDefaultAsync(m => m.ID == id);
	//	if (student == null) return NotFound();
	//	return View(student);
	//}

	[HttpPost] [ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind(properties)] Student s) => await create(s);

	[HttpPost, ActionName(nameof(Edit))] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] Student s) => await edit(id, s);
}
