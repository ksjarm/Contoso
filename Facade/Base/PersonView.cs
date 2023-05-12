using Contoso.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Contoso.Facade.Base;
public abstract class PersonView : NamedView {
    [DisplayName("Last Name")] public override string Name { get; set; }
    [Required][StringLength(50, MinimumLength = 3)][DisplayName("First name")] public string FirstName { get; set; }
    [DisplayName("Full Name")] public string FullName { get; set; }
    [DisplayName("Gender")] public IsoGender Gender { get; set; }
    [DisplayName("Photo")] public string Photo { get; set; }
}