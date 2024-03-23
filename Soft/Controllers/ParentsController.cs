using Microsoft.AspNetCore.Mvc;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;
using Contoso.Facade;
using Microsoft.AspNetCore.Mvc.Rendering;
using Contoso.Data;
using Contoso.Aids;

namespace Contoso.Soft.Controllers;
public class ParentsController : BaseController<IParentsRepo, Parent, ParentView> {
    private readonly List<string> genders;
    public ParentsController(IParentsRepo r = null, IStudentsRepo s = null) : base(r)
        => genders = Enum.GetValues(typeof(IsoGender)).Cast<IsoGender>().Select(EnumHelper.GetDescription).ToList();

    internal const string properties =
        $"{nameof(ParentView.ID)}, " +
        $"{nameof(ParentView.ValidFrom)}, " +
        $"{nameof(ParentView.ValidTo)}, " +
        $"{nameof(ParentView.Description)}, " +
        $"{nameof(ParentView.Code)}, " +
        $"{nameof(ParentView.FirstName)}, " +
        $"{nameof(ParentView.Name)}, " +
        $"{nameof(ParentView.FullName)}, " +
        $"{nameof(ParentView.Gender)}, " +
        $"{nameof(ParentView.PhotoView)}, " +
        $"{nameof(ParentView.PhotoUpload)}, " +
        $"{nameof(ParentView.PhoneNr)}, " +
        $"{nameof(ParentView.Relationships)}";

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] ParentView v) => await create(toDomain(v));

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] ParentView v) => await edit(id, toDomain(v));

    protected internal override void relatedLists(Parent selectedItem = null) {
        ViewBag.Genders = new SelectList(genders);
    }
    protected Parent toDomain(ParentView v) => new ParentViewFactory().Create(v);
    protected override ParentView toView(Parent o, bool load = false) => new ParentViewFactory().Create(o, load);
}