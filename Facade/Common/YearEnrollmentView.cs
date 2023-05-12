using System.ComponentModel.DataAnnotations;

namespace Contoso.Facade.Common;
public class YearEnrollmentView
{
    [DataType(DataType.Date)] public DateTime EnrollmentDate { get; set; }
    public int StudentCount { get; set; }
}