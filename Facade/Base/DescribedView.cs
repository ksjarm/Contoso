using System.ComponentModel;

namespace Contoso.Facade.Base;
public abstract class DescribedView : BaseView  {
    [DisplayName("Description")] public string Description { get; set; }
}
