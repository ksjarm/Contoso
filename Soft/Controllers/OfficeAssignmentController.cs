using Contoso.Domain.Repos;
using Contoso.Infra;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Soft.Controllers;

public class OfficeAssignmentController : Controller
{
    private readonly SchoolContext context;
    private readonly IOfficeAssignmentsRepo repo;
    public OfficeAssignmentController(SchoolContext c, IOfficeAssignmentsRepo r)
    {
        context = c;
        repo = r;
    }
}
