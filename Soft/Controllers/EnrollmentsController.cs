using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contoso.Domain;
using Contoso.Infra;
using Contoso.Domain.Repos;

namespace Contoso.Soft.Controllers;
public class EnrollmentsController : SchoolController<IEnrollmentsRepo, Enrollment> {
    public EnrollmentsController(SchoolContext c = null, IEnrollmentsRepo r = null) : base(c, r) { }
	protected internal override void relatedLists(Enrollment selectedItem = null) {
		ViewData["CourseID"] = new SelectList(context.Courses, "ID", "Name", selectedItem?.CourseID);
		ViewData["StudentID"] = new SelectList(context.Students, "ID", "FullName", selectedItem?.StudentID);
	}

	[HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID,CourseID,StudentID,Grade")] Enrollment enrollment) {
        if (ModelState.IsValid)
        {
            context.Add(enrollment);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
		relatedLists();
		return View(enrollment);
    }
    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("EnrollmentID,CourseID,StudentID,Grade")] Enrollment enrollment)
    {
        if (id != enrollment.ID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                context.Update(enrollment);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(enrollment.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
		relatedLists();
		return View(enrollment);
    }
    private bool EnrollmentExists(int id)
    {
        return (context.Enrollments?.Any(e => e.ID == id)).GetValueOrDefault();
    }
}
