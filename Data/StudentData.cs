using Contoso.Data.Base;

namespace Contoso.Data;
public class StudentData : PersonData {
    public DateTime EnrollmentDate { get; set; }
}