using System.ComponentModel;
using Contoso.Facade.Base;

namespace Contoso.Facade;
public sealed class ParentView : PersonView {
    [DisplayName("Phone Number")] public string PhoneNr { get; set; }
    //[DisplayName("Relationships")] public IEnumerable<RelationshipView> Relationships { get; set; }
}