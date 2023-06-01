using Contoso.Data.Base;
using Contoso.Domain.BaseRepos;
using Contoso.Facade.Base;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Soft.Controllers.Common;
public abstract class BaseController<TRepo, TDomain, TView> : Controller
    where TRepo : class, IRepo<TDomain> where TDomain : class, IEntity where TView : BaseView {

    protected readonly TRepo repo;
    public BaseController(TRepo r = null) => repo = r;
    public IActionResult Create() {
        relatedLists();
        return View();
    }
    public async Task<IActionResult> Delete(int id) => View(toView(await repo.GetAsync(id), true));

    [HttpPost, ActionName(nameof(Delete)), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
        => await repo.DeleteAsync(id) ? RedirectToAction(nameof(Index)) : NotFound();
    public async Task<IActionResult> Details(int id) => View(toView(await repo.GetAsync(id), true));
    public async Task<IActionResult> Edit(int id) {
        var item = await repo.GetAsync(id);
        relatedLists(item);
        return View(toView(item, true));
    }
    public async virtual Task<IActionResult> Index(string sortOrder, int pageIndex, string searchString, int? id, int? relatedId) {
        ViewData[Pages.Constants.Datas.SortOrder] = sortOrder;
        ViewData[Pages.Constants.Datas.Page] = getPage;
        ViewData[Pages.Constants.Datas.PageIndex] = pageIndex;
        ViewData[Pages.Constants.Datas.TotalPages] = repo.TotalPages;
        ViewData[Pages.Constants.Datas.CurrentFilter] = searchString;
        var objectList = await repo.GetAsync(sortOrder, pageIndex, searchString);
        var viewList = objectList.Select(x => toView(x)).ToList();
        return View(viewList);
    }
    protected abstract TView toView(TDomain o, bool load = false);
    protected internal async Task<IActionResult> create(TDomain item) {
        if (ModelState.IsValid && await repo.AddAsync(item)) return RedirectToAction(nameof(Index));
        relatedLists(item);
        var v = toView(item);
        return View(v);
    }
    protected internal async Task<IActionResult> edit(int id, TDomain item) {
        if (id != item.ID) return NotFound();
        if (ModelState.IsValid && await repo.UpdateAsync(item)) return RedirectToAction(nameof(Index));
        relatedLists(item);
        return View(toView(item));
    }
    internal string getPage => GetType().Name.Replace(nameof(Controller), string.Empty);
    protected internal virtual void relatedLists(TDomain selectedItem = null) { }
    public async Task<IActionResult> SelectItems(string searchString, string id) {
        var data = await repo.SelectItems(searchString, id);
        return Ok(data);
    }
    public async Task<IActionResult> SelectItem(string id) {
        var data = await repo.SelectItem(id);
        return Ok(data);
    }
}