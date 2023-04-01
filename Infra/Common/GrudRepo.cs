using Contoso.Domain;

namespace Contoso.Infra.Common;

public abstract class GrudRepo<T> : IGrudRepo<T> where T : IEntity {
	public bool Add(T obj) => throw new NotImplementedException();

	public bool Delete(int id) => throw new NotImplementedException();

	public IEnumerator<T> Get() => throw new NotImplementedException();

	public T Get(int id) => throw new NotImplementedException();

	public bool Update(T obj) => throw new NotImplementedException();
}
