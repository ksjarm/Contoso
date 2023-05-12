using Contoso.Data;
using Contoso.Domain;
using Contoso.Facade.Base;

namespace Contoso.Facade;
public sealed class CourseViewFactory : BaseViewFactory<CourseData, Course, CourseView> {
    protected internal override Course toObject(CourseData d) => new(d);
}