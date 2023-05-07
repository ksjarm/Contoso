using Contoso.Data.Base;

namespace Contoso.Data;
public sealed class InstructorData : PersonData {
    public DateTime HireDate { get; set; }
}