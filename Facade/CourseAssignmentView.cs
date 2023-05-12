using Contoso.Facade.Base;
using System.ComponentModel;

namespace Contoso.Facade;
public sealed class CourseAssignmentView : DescribedView {
    [DisplayName("Instructor")] public int InstructorID { get; set; }
    [DisplayName("Instructor")] public string InstructorName { get; set; }
    [DisplayName("Course")] public int CourseID { get; set; }
    [DisplayName("Course")] public string CourseName { get; set; }
}
