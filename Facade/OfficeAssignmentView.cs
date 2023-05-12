using Contoso.Facade.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Facade;
public sealed class OfficeAssignmentView : DescribedView {
    [DisplayName("Instructor")] public int InstructorID { get; set; }
    [DisplayName("Instructor")] public string InstructorName { get; set; }
    [StringLength(50)] [DisplayName("Office Location")] public string Location { get; set; }
}