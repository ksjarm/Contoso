using System.ComponentModel.DataAnnotations;

namespace Contoso.Facade;
public class EnrollmentDateGroup {
    [DataType(DataType.Date)] [Display(Name = "Enrollment Date")] public DateTime EnrollmentDate { get; set; }
    public int StudentCount { get; set; }
}