using Microsoft.AspNetCore.Mvc;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;
using Contoso.Facade;
using Microsoft.AspNetCore.Mvc.Rendering;
using Contoso.Data;
using Contoso.Aids;

namespace Contoso.Soft.Controllers;
public class StudentsController : BaseController<IStudentsRepo, Student, StudentView> {
    private readonly List<string> genders;
    public StudentsController(IStudentsRepo r = null) : base(r)
        => genders = Enum.GetValues(typeof(IsoGender)).Cast<IsoGender>().Select(EnumHelper.GetDescription).ToList();

    internal const string properties =
        $"{nameof(StudentView.ID)}, " +
        $"{nameof(StudentView.ValidFrom)}, " +
        $"{nameof(StudentView.ValidTo)}, " +        
        $"{nameof(StudentView.Description)}, " +
        $"{nameof(StudentView.Code)}, " +
        $"{nameof(StudentView.FirstName)}, " +
        $"{nameof(StudentView.Name)}, " +
	    $"{nameof(StudentView.FullName)}, " +
        $"{nameof(StudentView.Gender)}, " +
        $"{nameof(StudentView.PhotoView)}, " +
        $"{nameof(StudentView.PhotoUpload)}, " +
        $"{nameof(StudentView.EnrollmentDate)}";

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] StudentView v) => await create(toDomain(v));

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] StudentView v) => await edit(id, toDomain(v));

    protected internal override void relatedLists(Student selectedItem = null) {
        ViewBag.Genders = new SelectList(genders);
    }
    protected Student toDomain(StudentView v) => new StudentViewFactory().Create(v);
    protected override StudentView toView(Student o, bool load = false) => new StudentViewFactory().Create(o, load);
}