using Contoso.Facade.Base;
using System.ComponentModel;

namespace Contoso.Facade;
public sealed class RelationshipView : DescribedView {
    [DisplayName("Student")] public int StudentID { get; set; }
    [DisplayName("Student")] public string StudentName { get; set; }
    [DisplayName("Parent")] public int ParentID { get; set; }
    [DisplayName("Parent")] public string ParentName { get; set; }
}