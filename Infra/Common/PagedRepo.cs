using Contoso.Domain;
using Contoso.Domain.Repos;

namespace Contoso.Infra.Common;

public class PagedRepo<T> : OrderedRepo<T>, IPagedRepo<T> where T : IEntity
{
}
