using Contoso.Data.Base;

namespace Contoso.Data;
public sealed class OfficeAssignmentData : DescribedData {
    public int InstructorID { get; set; }
    public string Location { get; set; }
}