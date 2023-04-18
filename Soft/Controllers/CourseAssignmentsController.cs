using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra;
using Contoso.Soft.Controllers.Common;

namespace Contoso.Soft.Controllers;
public class CourseAssignmentsController : SchoolController<ICourseAssignmentsRepo, CourseAssignment> {
    public CourseAssignmentsController(SchoolContext c, ICourseAssignmentsRepo r) : base(c, r) { }
}