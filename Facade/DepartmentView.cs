using Contoso.Facade.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contoso.Facade;
public sealed class DepartmentView : NamedView {
    [DataType(DataType.Currency)] [Column(TypeName = "money")] public decimal Budget { get; set; }
    [DataType(DataType.Date)] [DisplayName("Start Date")] public DateTime? StartDate { get; set; }
    [DisplayName("Instructor")] public int? InstructorID { get; set; }
	[DisplayName("Instructor")] public string InstructorName { get; set; }
}