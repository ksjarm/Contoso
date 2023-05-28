using Contoso.Data;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;

namespace Contoso.Infra;
public class OfficeAssignmentsRepo : BaseRepo<OfficeAssignment, OfficeAssignmentData>, IOfficeAssignmentsRepo {
    public OfficeAssignmentsRepo(SchoolContext c) : base(c, c.OfficeAssignments) { }
    protected internal override IQueryable<OfficeAssignmentData> addFilter(IQueryable<OfficeAssignmentData> s) {
        var v = CurrentFilter;
        return string.IsNullOrWhiteSpace(v) ? base.addFilter(s) :
             s.Where(x => x.InstructorID.ToString().Contains(v) ||
               x.Location.Contains(v) ||
               x.Description.Contains(v) ||
               x.ValidFrom.ToString().Contains(v) ||
               x.ValidTo.ToString().Contains(v));
    }
    protected override OfficeAssignmentData toData(OfficeAssignment o) => o.data;
    protected override OfficeAssignment toDomain(OfficeAssignmentData d) => new(d);
}