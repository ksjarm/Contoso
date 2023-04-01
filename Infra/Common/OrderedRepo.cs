using Contoso.Domain;
using Contoso.Domain.Repos;

namespace Contoso.Infra.Common;

public abstract class OrderedRepo<T> : FilteredRepo<T>, IOrderedRepo<T> where T : IEntity { }
