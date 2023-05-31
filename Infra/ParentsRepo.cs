using Contoso.Data;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;

namespace Contoso.Infra;
public class ParentsRepo : BaseRepo<Parent, ParentData>, IParentsRepo {
    public ParentsRepo(SchoolContext c) : base(c, c.Parents) { }
    public override string selectTextField => nameof(ParentData.Name);
    protected internal override IQueryable<ParentData> addFilter(IQueryable<ParentData> s) {
        var v = CurrentFilter;
        return string.IsNullOrWhiteSpace(v) ? base.addFilter(s) :
             s.Where(x => x.Name.Contains(v) ||
               x.FirstName.Contains(v) ||
               x.Gender.ToString().Contains(v) ||
               x.PhoneNr.Contains(v) ||
               x.Code.Contains(v) ||
               x.Description.Contains(v) ||
               x.ValidFrom.ToString().Contains(v) ||
               x.ValidTo.ToString().Contains(v));
    }
    protected override ParentData toData(Parent o) => o?.Data;
    protected override Parent toDomain(ParentData d) => new(d);
}