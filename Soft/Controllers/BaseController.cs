using Contoso.Data;
using Contoso.Domain.BaseRepos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Soft.Controllers;
public class BaseController<TContext, TRepo, TDomain> : Controller
	where TContext : DbContext where TRepo : class, IRepo<TDomain> where TDomain : class, IEntity {

	protected readonly TContext context;
	protected readonly TRepo repo;
	public BaseController(TContext c = null, TRepo r = null) {
		context = c;
		repo = r;
	}
	internal string getPage => GetType().Name.Replace(nameof(Controller), string.Empty);
	public async Task<IActionResult> Index(string sortOrder, int pageIndex, string searchString) {
		ViewData[Pages.Constants.Data.SortOrder] = sortOrder;
		ViewData[Pages.Constants.Data.Page] = getPage;
		ViewData[Pages.Constants.Data.PageIndex] = pageIndex;
		ViewData[Pages.Constants.Data.TotalPages] = repo.TotalPages;
		ViewData[Pages.Constants.Data.CurrentFilter] = searchString;
		return View(await repo.GetAsync(sortOrder, pageIndex, searchString));
	}
	public IActionResult Create() {
		relatedLists();
		return View();
	}
	public async Task<IActionResult> Edit(int? id) {
        var item = await repo.GetAsync(id);
        relatedLists(item);
        return View(item);
    }
	protected internal virtual void relatedLists(TDomain selectedItem = null) { }
	public async Task<IActionResult> Details(int? id) => View(await repo.GetAsync(id));
	public async Task<IActionResult> Delete(int? id) => View(await repo.GetAsync(id));

	[HttpPost, ActionName(nameof(Delete))] [ValidateAntiForgeryToken]
	public async Task<IActionResult> DeleteConfirmed(int id) {
		await repo.DeleteAsync(id);
		return RedirectToAction(nameof(Index));
	}
}