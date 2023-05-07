using Contoso.Data.Base;

namespace Contoso.Data;
public sealed class CourseAssignmentData : DescribedData {
    public int InstructorID { get; set; }
    public int CourseID { get; set; }
}
