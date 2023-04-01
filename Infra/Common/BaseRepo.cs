using Contoso.Domain;
using Contoso.Domain.Repos;

namespace Contoso.Infra.Common;

public abstract class BaseRepo<T> : PagedRepo<T>, IRepo<T> where T : IEntity { }
