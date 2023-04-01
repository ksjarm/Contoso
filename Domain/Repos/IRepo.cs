namespace Contoso.Domain.Repos;

public interface IRepo<T> : IPagedRepo<T> where T : IEntity
{

}
