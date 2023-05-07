using Contoso.Data.Base;

namespace Contoso.Data;
public sealed class EnrollmentData : DescribedData {
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    public Grade? Grade { get; set; }
}