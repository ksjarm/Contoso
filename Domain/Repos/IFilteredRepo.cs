namespace Contoso.Domain.Repos;

public interface IFilteredRepo<T> : IGrudRepo<T> where T : IEntity
{

}
