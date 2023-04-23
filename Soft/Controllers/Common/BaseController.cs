using Contoso.Data;
using Contoso.Domain.BaseRepos;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Soft.Controllers.Common;
public class BaseController<TRepo, TDomain> : Controller
    where TRepo : class, IRepo<TDomain> where TDomain : class, IEntity {

    protected readonly TRepo repo;
    public BaseController( TRepo r = null) => repo = r;
    internal string getPage => GetType().Name.Replace(nameof(Controller), string.Empty);
    public async virtual Task<IActionResult> Index(string sortOrder, int pageIndex, string searchString, int? id, int? relatedId) {
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
    public async Task<IActionResult> DeleteConfirmed(int id) 
        => await repo.DeleteAsync(id) ? RedirectToAction(nameof(Index)) : NotFound();
    protected internal async Task<IActionResult> create(TDomain item) {
        if (ModelState.IsValid && await repo.AddAsync(item)) return RedirectToAction(nameof(Index));
        relatedLists(item);
        return View(item);
    }
    protected internal async Task<IActionResult> edit(int id, TDomain item) {
        if (id != item.ID) return NotFound();
        if (ModelState.IsValid && await repo.UpdateAsync(item)) return RedirectToAction(nameof(Index));
        relatedLists(item);
        return View(item);
    }
}