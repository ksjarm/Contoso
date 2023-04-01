namespace Contoso.Domain.Repos;

public interface IPagedRepo<T> : IOrderedRepo<T> where T : IEntity
{

}
