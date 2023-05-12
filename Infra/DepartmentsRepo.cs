using Contoso.Data;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra;
public class DepartmentsRepo : BaseRepo<Department, DepartmentData>, IDepartmentsRepo {
    public DepartmentsRepo(SchoolContext c) : base(c, c.Departments) { }
    public override string selectTextField => nameof(DepartmentData.Name);
    protected internal override IQueryable<DepartmentData> addFilter(IQueryable<DepartmentData> s) {
        var v = CurrentFilter;
        return string.IsNullOrWhiteSpace(v) ? base.addFilter(s) :
             s.Where(x => x.Name.Contains(v) ||
               x.Code.Contains(v) ||
               x.Description.Contains(v) ||
               x.ValidFrom.ToString().Contains(v) ||
               x.ValidTo.ToString().Contains(v) ||
               x.Budget.ToString().Contains(v) ||
               x.StartDate.ToString().Contains(v));
    }
    protected override DepartmentData toData(Department o) => o.data;
    protected override Department toDomain(DepartmentData d) => new (d);
}
