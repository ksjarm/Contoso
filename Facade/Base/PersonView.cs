using Contoso.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Contoso.Facade.Base;
public abstract class PersonView : NamedView {
    [Required][StringLength(50, MinimumLength = 2)][DisplayName("First Name")] public string FirstName { get; set; }
    [DisplayName("Last Name")] public override string Name { get; set; }
    [DisplayName("Full Name")] public string FullName { get; set; }
    [DisplayName("Gender")] public IsoGender Gender { get; set; }
	[DisplayName("Photo")] public string PhotoView { get; set; }
    [DisplayName("Photo File")] public IFormFile PhotoUpload { get; set; }
}