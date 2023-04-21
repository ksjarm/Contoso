using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Domain.Base;
public abstract class NamedEntity : BaseEntity {
    [Required] [StringLength(50, MinimumLength = 3)] [DisplayName("Name")] public virtual string Name { get; set; }
}
