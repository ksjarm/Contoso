using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Contoso.Facade;
using Contoso.Infra;

namespace Contoso.Soft.Controllers;
public class HomeController : Controller {
    private readonly ILogger<HomeController> logger;
    private readonly SchoolContext context;
    public HomeController(ILogger<HomeController> l, SchoolContext c = null) {
        logger = l;
        context = c;
    }
    public IActionResult Index() => View();
    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    public async Task<ActionResult> About() {
        IQueryable<EnrollmentDateGroup> data =
            from student in context.Students
            group student by student.EnrollmentDate into dateGroup
            orderby dateGroup.Key descending
            select new EnrollmentDateGroup() {
                EnrollmentDate = dateGroup.Key,
                StudentCount = dateGroup.Count()
            };
        return View(await data.AsNoTracking().ToListAsync());
    }
}