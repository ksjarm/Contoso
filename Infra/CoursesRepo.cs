using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;

namespace Contoso.Infra;
public class CoursesRepo : BaseRepo<Course>, ICoursesRepo {
    public CoursesRepo(SchoolContext c) : base(c, c.Courses) { }
}
