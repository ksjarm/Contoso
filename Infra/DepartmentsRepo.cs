using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;

namespace Contoso.Infra;
public class DepartmentsRepo : BaseRepo<Department>, IDepartmentsRepo {
    public DepartmentsRepo(SchoolContext c) : base(c, c.Departments) { }
}
