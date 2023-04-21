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
	
	[HttpPost] [ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind(properties)] Student s) => await create(s);

	[HttpPost, ActionName(nameof(Edit))] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] Student s) => await edit(id, s);
}
