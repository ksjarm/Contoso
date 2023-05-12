using Contoso.Data.Base;

namespace Contoso.Data;
public sealed class CourseAssignmentData : DescribedData {
    public int CourseID { get; set; }
    public int InstructorID { get; set; }
}