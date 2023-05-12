using Contoso.Data;
using Contoso.Facade.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Facade;
public sealed class EnrollmentView : DescribedView {
    [DisplayName("Course")] public int CourseID { get; set; }
    [DisplayName("Course")] public string CourseName { get; set; }
    [DisplayName("Student")] public int StudentID { get; set; }
    [DisplayName("Student")] public string StudentName { get; set; }
    [DisplayFormat(NullDisplayText = "No grade")] [DisplayName("Grade")] public Grade? Grade { get; set; }
}