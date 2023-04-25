using Contoso.Domain;

namespace Contoso.Facade;
public sealed class CourseViewFactory {
    public CourseView Create(Course c) => new () {
            ID = c.ID,
            Name = c.Name,
            Credits = c.Credits,
            DepartmentID = c.DepartmentID,
            DepartmentName = c.Department.Name,
            Number = c.Number
        };
}
