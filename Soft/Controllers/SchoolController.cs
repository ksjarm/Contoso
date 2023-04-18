using Contoso.Data;
using Contoso.Domain.BaseRepos;
using Contoso.Infra;

namespace Contoso.Soft.Controllers;
public class SchoolController<TRepo, TDomain> : BaseController<SchoolContext, TRepo, TDomain>
    where TRepo : class, IRepo<TDomain> where TDomain : class, IEntity {
    public SchoolController(SchoolContext c = null, TRepo r = null) : base(c, r) { }
}