using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra;
public class DepartmentsRepo : BaseRepo<Department>, IDepartmentsRepo {
    public DepartmentsRepo(SchoolContext c) : base(c, c.Departments) { }
    protected internal override IQueryable<Department> сreateSQL() => addAggregates(base.сreateSQL());
    protected internal override IQueryable<Department> addAggregates(IQueryable<Department> sql)
        => sql.Include(e => e.Administrator);
}
