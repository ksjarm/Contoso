using Microsoft.AspNetCore.Mvc;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;
using Contoso.Facade;

namespace Contoso.Soft.Controllers;
public class StudentsController : BaseController<IStudentsRepo, Student, StudentView> {
	public StudentsController(IStudentsRepo r = null) : base(r) { }

    internal const string properties = 
		$"{nameof(StudentView.ID)}," +
		$"{nameof(StudentView.FirstName)}," +
		$"{nameof(StudentView.Name)}," +
		$"{nameof(StudentView.PhotoUpload)}" +
        $"{nameof(StudentView.EnrollmentDate)}";

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] StudentView v) => await create(toDomain(v));

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] StudentView c) => await edit(id, toDomain(c));

    protected Student toDomain(StudentView v) => new StudentViewFactory().Create(v);
    protected override StudentView toView(Student o, bool load = false) => new StudentViewFactory().Create(o, load);
}