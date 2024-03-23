using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Contoso.Facade.Base;

namespace Contoso.Facade;
public sealed class ParentView : PersonView {
	[DataType(DataType.PhoneNumber)] [DisplayName("Phone Number")]
	[Range(1000000, 99999999, ErrorMessage = "Phone number must be 7-8 digits.")] public int PhoneNr { get; set; }
	[DisplayName("Relationships")] public IEnumerable<StudentView> Relationships { get; set; }
}