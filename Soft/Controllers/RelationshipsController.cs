using Microsoft.AspNetCore.Mvc;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;
using Contoso.Facade;
using Contoso.Domain;

namespace Contoso.Soft.Controllers;
public class RelationshipsController : BaseController<IRelationshipsRepo, Relationship, RelationshipView> {
    private readonly IParentsRepo parents;
    private readonly IStudentsRepo students;
    public RelationshipsController(IRelationshipsRepo r = null, IStudentsRepo s = null, IParentsRepo p = null) : base(r) {
        students = s;
        parents = p;
    }

    internal const string properties =
        $"{nameof(RelationshipView.ID)}, " +
        $"{nameof(RelationshipView.ValidFrom)}, " +
        $"{nameof(RelationshipView.ValidTo)}, " +
        $"{nameof(RelationshipView.Description)}, " +
        $"{nameof(RelationshipView.StudentID)}, " +
        $"{nameof(RelationshipView.StudentName)}, " +
        $"{nameof(RelationshipView.ParentID)}, " +
        $"{nameof(RelationshipView.ParentName)}";

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] RelationshipView v) => await create(toDomain(v));

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] RelationshipView v) => await edit(id, toDomain(v));

    protected internal override void relatedLists(Relationship e = null) {
        ViewBag.Students = students?.SelectList;
        ViewBag.Parents = parents?.SelectList;
    }
    protected Relationship toDomain(RelationshipView v) => new RelationshipViewFactory().Create(v);
    protected override RelationshipView toView(Relationship v, bool load = false) => new RelationshipViewFactory().Create(v, load);
}