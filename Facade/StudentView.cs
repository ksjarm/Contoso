using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Contoso.Facade.Base;

namespace Contoso.Facade;
public sealed class StudentView : PersonView {
    [DataType(DataType.Date)][DisplayName("Enrollment Date")] public DateTime EnrollmentDate { get; set; }
    [DisplayName("Enrollments")] public IEnumerable<CourseView> Enrollments { get; set; }
    //[DisplayName("Relationships")] public IEnumerable<RelationshipView> Relationships { get; set; }
}