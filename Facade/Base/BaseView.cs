using Contoso.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Facade.Base;
public abstract class BaseView : IEntity {
    public int ID { get; set; }
    [DisplayName("Valid from")] public DateTime ValidFrom { get; set; }
    [DisplayName("Valid to")] public DateTime ValidTo { get; set; }
    //[Timestamp] public byte[] RowVersion { get; set; } = Array.Empty<byte>();
}