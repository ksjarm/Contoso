using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra;
public class DepartmentsRepo : BaseRepo<Department, Department>, IDepartmentsRepo {
    public DepartmentsRepo(SchoolContext c) : base(c, c.Departments) { }
    public override string selectTextField => nameof(Department.Name);
    protected internal override IQueryable<Department> createSQL() => addAggregates(base.createSQL());
    protected internal override IQueryable<Department> addAggregates(IQueryable<Department> sql)
        => sql.Include(e => e.Administrator);
    protected override Department toDomain(Department d) => d;

    protected override Department toData(Department o) => o;
}
