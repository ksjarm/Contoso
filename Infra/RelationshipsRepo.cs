using Contoso.Data;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;

namespace Contoso.Infra;
public class RelationshipsRepo : BaseRepo<Relationship, RelationshipData>, IRelationshipsRepo {
    public RelationshipsRepo(SchoolContext c) : base(c, c.Relationships) { }
    protected internal override IQueryable<RelationshipData> addFilter(IQueryable<RelationshipData> s) {
        var v = CurrentFilter;
        return string.IsNullOrWhiteSpace(v) ? base.addFilter(s) :
             s.Where(x => x.StudentID.ToString().Contains(v) ||
               x.ParentID.ToString().Contains(v) ||
               x.Description.Contains(v) ||
               x.ValidFrom.ToString().Contains(v) ||
               x.ValidTo.ToString().Contains(v));
    }
    protected override RelationshipData toData(Relationship o) => o?.Data;
    protected override Relationship toDomain(RelationshipData d) => new(d);
}