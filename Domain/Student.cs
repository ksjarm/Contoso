using System.ComponentModel.DataAnnotations;
using Contoso.Domain.Base;

namespace Contoso.Domain;
public class Student : Person {
    [DataType(DataType.Date)] public DateTime EnrollmentDate { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
}