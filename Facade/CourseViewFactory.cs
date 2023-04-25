using Contoso.Data;
using Contoso.Domain;

namespace Contoso.Facade;
public sealed class CourseViewFactory {
    public CourseView Create(Course c) => new () {
            ID = c.ID,
            Name = c.Name,
            Credits = c.Credits,
            DepartmentID = c.DepartmentID,
            DepartmentName = c.Department?.Name,
            Number = c.Number
        };
    public Course Create(CourseView v) {
        var d = new CourseData() { 
            ID = v.ID,
            Name = v.Name,
            Credits = v.Credits,
            DepartmentID = v.DepartmentID,
            Number = v.Number
        };
    return new Course(d);
    }
}
