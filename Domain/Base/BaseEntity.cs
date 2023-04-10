using Contoso.Data;

namespace Contoso.Domain.Base;
public abstract class BaseEntity : IEntity {
    public int ID { get; set; }
}
