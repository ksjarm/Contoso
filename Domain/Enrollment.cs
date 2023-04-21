using Contoso.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Domain;
public class Enrollment : BaseEntity {
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    [DisplayFormat(NullDisplayText = "No grade")] public Grade? Grade { get; set; }
    public Course? Course { get; set; }
    public Student? Student { get; set; }
}