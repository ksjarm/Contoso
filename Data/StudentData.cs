using Contoso.Data.Base;

namespace Contoso.Data;
public sealed class StudentData : PersonData {
    public DateTime EnrollmentDate { get; set; }
}