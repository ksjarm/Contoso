using System.ComponentModel.DataAnnotations;

namespace Contoso.Domain.Base;
public abstract class Person : NamedEntity {
    [Display(Name = "Last Name")] public override string? Name { get; set; }
    [Required] [StringLength(50)] [Display(Name = "First Name")] public string? FirstMidName { get; set; }
    [Display(Name = "Full Name")] public string FullName => Name + ", " + FirstMidName;
}