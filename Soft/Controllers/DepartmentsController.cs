using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contoso.Domain;
using Contoso.Infra;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;

namespace Contoso.Soft.Controllers;
public class DepartmentsController : BaseController<IDepartmentsRepo, Department> {
    private readonly SchoolContext context;
    public DepartmentsController(SchoolContext c, IDepartmentsRepo r = null) : base(r) => context = c;
    
    internal const string properties = 
        $"{nameof(Department.ID)}," +
        $"{nameof(Department.Name)}," +
        $"{nameof(Department.Budget)}," +
        $"{nameof(Department.StartDate)}," +
        $"{nameof(Department.InstructorID)}";

    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] Department department) => await create(department);

    [HttpPost] [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, byte[] rowVersion) {
        if (id == null) return NotFound();

        var departmentToUpdate = await context.Departments.Include(i => i.Administrator).FirstOrDefaultAsync(m => m.ID == id);

        if (departmentToUpdate == null) {
            Department deletedDepartment = new Department();
            await TryUpdateModelAsync(deletedDepartment);
            ModelState.AddModelError(string.Empty,
                "Unable to save changes. The department was deleted by another user.");
            ViewData["InstructorID"] = new SelectList(context.Instructors, "ID", "FullName", deletedDepartment.InstructorID);
            return View(deletedDepartment);
        }

        context.Entry(departmentToUpdate).Property("RowVersion").OriginalValue = rowVersion;

        if (await TryUpdateModelAsync(
            departmentToUpdate,
            "",
            s => s.Name, s => s.StartDate, s => s.Budget, s => s.InstructorID))
        {
            try
            {
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var exceptionEntry = ex.Entries.Single();
                var clientValues = (Department)exceptionEntry.Entity;
                var databaseEntry = exceptionEntry.GetDatabaseValues();
                if (databaseEntry == null)
                {
                    ModelState.AddModelError(string.Empty,
                        "Unable to save changes. The department was deleted by another user.");
                }
                else
                {
                    var databaseValues = (Department)databaseEntry.ToObject();

                    if (databaseValues.Name != clientValues.Name)
                    {
                        ModelState.AddModelError("Name", $"Current value: {databaseValues.Name}");
                    }
                    if (databaseValues.Budget != clientValues.Budget)
                    {
                        ModelState.AddModelError("Budget", $"Current value: {databaseValues.Budget:c}");
                    }
                    if (databaseValues.StartDate != clientValues.StartDate)
                    {
                        ModelState.AddModelError("StartDate", $"Current value: {databaseValues.StartDate:d}");
                    }
                    if (databaseValues.InstructorID != clientValues.InstructorID)
                    {
                        Instructor databaseInstructor = await context.Instructors.FirstOrDefaultAsync(i => i.ID == databaseValues.InstructorID);
                        ModelState.AddModelError("InstructorID", $"Current value: {databaseInstructor?.FullName}");
                    }

                    ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                            + "was modified by another user after you got the original value. The "
                            + "edit operation was canceled and the current values in the database "
                            + "have been displayed. If you still want to edit this record, click "
                            + "the Save button again. Otherwise click the Back to List hyperlink.");
                    //departmentToUpdate.RowVersion = databaseValues.RowVersion;
                    //ModelState.Remove("RowVersion");
                }
            }
        }
        ViewData["InstructorID"] = new SelectList(context.Instructors, "ID", "FullName", departmentToUpdate.InstructorID);
        return View(departmentToUpdate);
    }
    private bool DepartmentExists(int id) => context.Departments.Any(e => e.ID == id);
}
