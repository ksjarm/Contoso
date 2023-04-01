namespace Contoso.Domain.Repos;

public interface IOrderedRepo<T> : IFilteredRepo<T> where T : IEntity
{

}
