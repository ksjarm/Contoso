using Microsoft.AspNetCore.Mvc;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;

namespace Contoso.Soft.Controllers;
public class StudentsController : BaseController<IStudentsRepo, Student> {
	public StudentsController(IStudentsRepo r = null) : base(r) { }
    
	internal const string properties = 
		$"{nameof(Student.ID)}," +
		$"{nameof(Student.EnrollmentDate)}," +
		$"{nameof(Student.FirstName)}," +
		$"{nameof(Student.Name)}";
	
	[HttpPost] [ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind(properties)] Student s) => await create(s);

	[HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] Student s) => await edit(id, s);
}
