using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Contoso.Facade.Base;
public abstract class NamedView : DescribedView {
    [DisplayName("Code")] public string Code { get; set; }
    [Required][StringLength(50, MinimumLength = 2)][DisplayName("Name")] public virtual string Name { get; set; }
}