using Contoso.Domain.Repos;
using Contoso.Infra;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Soft.Controllers;
public class CourseAssignmentsController : Controller {
    private readonly SchoolContext context;
    private readonly ICourseAssignmentsRepo repo;
    public CourseAssignmentsController(SchoolContext c, ICourseAssignmentsRepo r)
    {
        context = c;
        repo = r;
    }
}