using Contoso.Data;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;

namespace Contoso.Infra;
public class InstructorsRepo : BaseRepo<Instructor, InstructorData>, IInstructorsRepo {
    public InstructorsRepo(SchoolContext c) : base(c, c.Instructors) { }
    public override string selectTextField => nameof(InstructorData.Name);
    protected internal override IQueryable<InstructorData> addFilter(IQueryable<InstructorData> s) {
        var v = CurrentFilter;
        return string.IsNullOrWhiteSpace(v) ? base.addFilter(s) :
             s.Where(x => x.Name.Contains(v) ||
               x.FirstName.Contains(v) ||
               x.Gender.ToString().Contains(v) ||
               x.HireDate.ToString().Contains(v) ||
               x.Code.Contains(v) ||
               x.Description.Contains(v) ||
               x.ValidFrom.ToString().Contains(v) ||
               x.ValidTo.ToString().Contains(v));
    }
    protected override InstructorData toData(Instructor o) => o?.Data;
    protected override Instructor toDomain(InstructorData d) => new(d);
}