using Microsoft.AspNetCore.Mvc;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;
using Contoso.Facade.Common;
using Contoso.Facade;
using Contoso.Pages.Constants;
using Contoso.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Contoso.Soft.Controllers;
public class InstructorsController : BaseController<IInstructorsRepo, Instructor, InstructorView> {
    private readonly List<IsoGender> genders;
    public InstructorsController(IInstructorsRepo r = null) : base(r)
        => genders = Enum.GetValues(typeof(IsoGender)).Cast<IsoGender>().ToList();

    internal const string properties =
        $"{nameof(InstructorView.ID)}, " +
        $"{nameof(InstructorView.ValidFrom)}, " +
        $"{nameof(InstructorView.ValidTo)}, " +
        $"{nameof(InstructorView.Description)}, " +
        $"{nameof(InstructorView.Code)}, " +
        $"{nameof(InstructorView.FirstName)}, " +
        $"{nameof(InstructorView.Name)}, " +
        $"{nameof(InstructorView.FullName)}, " +
        $"{nameof(InstructorView.Gender)}, " +
        $"{nameof(InstructorView.PhotoView)}, " +
		$"{nameof(InstructorView.PhotoUpload)}, " +
        $"{nameof(InstructorView.HireDate)}, " +
        $"{nameof(InstructorView.Office)}";

    public async override Task<IActionResult> Index(string sortOrder, int pageIndex, string searchString, int? id, int? relatedId) {
        ViewData[Datas.SortOrder] = sortOrder;
        ViewData[Datas.Page] = getPage;
        ViewData[Datas.PageIndex] = pageIndex;
        ViewData[Datas.TotalPages] = repo.TotalPages;
        ViewData[Datas.CurrentFilter] = searchString;
        var viewModel = new InstructorIndexView();
        viewModel.Instructors = await repo.GetAsync(sortOrder, pageIndex, searchString);
        if (id != null) {
            ViewData["InstructorID"] = id.Value;
            Instructor instructor = viewModel.Instructors.Where(i => i.ID == id.Value).FirstOrDefault();
            viewModel.Courses = instructor?.CourseAssignments?.Value?.Select(s => s?.Course?.Value);
        }
        if (relatedId != null) {
            ViewData["CourseID"] = relatedId.Value;
            var selectedCourse = viewModel.Courses?.Where(x => x.ID == relatedId).FirstOrDefault();
            if (selectedCourse != null) {
                viewModel.Enrollments = selectedCourse?.Enrollments?.Value;
            }
        }
        return View(viewModel);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] InstructorView v) => await create(toDomain(v));

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(properties)] InstructorView v) => await edit(id, toDomain(v));

    protected internal override void relatedLists(Instructor selectedItem = null) {
        ViewBag.Genders = new SelectList(genders);
    }
    protected Instructor toDomain(InstructorView v) => new InstructorViewFactory().Create(v);
    protected override InstructorView toView(Instructor o, bool load = false) => new InstructorViewFactory().Create(o, load);
}