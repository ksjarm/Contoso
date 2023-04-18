using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Contoso.Domain;
using Contoso.Infra;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;

namespace Contoso.Soft.Controllers;
public class EnrollmentsController : SchoolController<IEnrollmentsRepo, Enrollment> {
    public EnrollmentsController(SchoolContext c = null, IEnrollmentsRepo r = null) : base(c, r) { }

	internal const string properties = $"{nameof(Enrollment.ID)}, {nameof(Enrollment.CourseID)}, " +
		$"{nameof(Enrollment.StudentID)}, {nameof(Enrollment.Grade)}";
	protected internal override void relatedLists(Enrollment selectedItem = null) {
		ViewData["CourseID"] = new SelectList(context.Courses, "ID", "Name", selectedItem?.CourseID);
		ViewData["StudentID"] = new SelectList(context.Students, "ID", "FullName", selectedItem?.StudentID);
	}

    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] Enrollment enrollment) => await create(enrollment);
    
    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] Enrollment enrollment) => await edit(id, enrollment);
}
