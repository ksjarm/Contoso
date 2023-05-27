using Contoso.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Facade.Base;
public abstract class BaseView : IEntity {
    public int ID { get; set; }
    [DataType(DataType.Date)][DisplayName("Valid from")] public DateTime ValidFrom { get; set; }
    [DataType(DataType.Date)][DisplayName("Valid to")] public DateTime ValidTo { get; set; }
}