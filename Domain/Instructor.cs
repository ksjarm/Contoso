using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Contoso.Domain.Base;

namespace Contoso.Domain;
public class Instructor : Person {
    [DataType(DataType.Date)] [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Hire Date")] public DateTime HireDate { get; set; }

    [DisplayName("Taught courses")] public ICollection<CourseAssignment>? CourseAssignments { get; set; }
    [DisplayName("Office")] public OfficeAssignment? OfficeAssignment { get; set; }
}