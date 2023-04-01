using Contoso.Domain;
using Contoso.Domain.Repos;

namespace Contoso.Infra.Common;

public abstract class FilteredRepo<T> : GrudRepo<T>, IFilteredRepo<T> where T : IEntity { }
