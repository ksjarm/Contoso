using Contoso.Data;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Domain.Base;
public abstract class BaseEntity : IEntity {
    public int ID { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo  { get; set; }
    //[Timestamp] public byte[]? RowVersion { get; set; } = Array.Empty<byte>();
}
