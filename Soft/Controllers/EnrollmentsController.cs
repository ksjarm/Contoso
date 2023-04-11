using Contoso.Domain.Repos;
using Contoso.Infra;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Soft.Controllers;

public class EnrollmentsController : Controller
{
    private readonly SchoolContext context;
    private readonly IEnrollmentsRepo repo;
    public EnrollmentsController(SchoolContext c, IEnrollmentsRepo r)
    {
        context = c;
        repo = r;
    }
}
