using Contoso.Data;
using Contoso.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contoso.Domain;
public class Department : NamedEntity {
    [DataType(DataType.Currency)] [Column(TypeName = "money")] public decimal Budget { get; set; }
    
    [DataType(DataType.Date)] [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Start Date")] public DateTime? StartDate { get; set; }

    //[Timestamp] public byte[]? RowVersion { get; set; }
    [Display(Name = "Instructor")] public int? InstructorID { get; set; }
    public Instructor Administrator { get; set; }
    public ICollection<CourseData> Courses { get; set; }
}