using Contoso.Infra;
using Contoso.Soft.Data;
using Microsoft.EntityFrameworkCore;
using Contoso.Domain.Repos;
using Contoso.Domain.BaseRepos;
using System.Globalization;

namespace Contoso.Soft;
public class Program {
    public static void Main(string[] args) {
        CultureInfo cultureInfo = new CultureInfo("et-EE");
        cultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
        cultureInfo.DateTimeFormat.LongTimePattern = "";
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;

        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddDbContext<SchoolContext>(options 
            => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddDbContext<ApplicationDbContext>(options 
            => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        builder.Services.AddControllersWithViews();

        builder.Services.AddTransient<IInstructorsRepo, InstructorsRepo>();
        builder.Services.AddTransient<IStudentsRepo, StudentsRepo>();
        builder.Services.AddTransient<IParentsRepo, ParentsRepo>();
        builder.Services.AddTransient<ICoursesRepo, CoursesRepo>();
        builder.Services.AddTransient<IDepartmentsRepo, DepartmentsRepo>();
        builder.Services.AddTransient<IEnrollmentsRepo, EnrollmentsRepo>();
        builder.Services.AddTransient<IRelationshipsRepo, RelationshipsRepo>();
        builder.Services.AddTransient<IOfficeAssignmentsRepo, OfficeAssignmentsRepo>();
        builder.Services.AddTransient<ICourseAssignmentsRepo, CourseAssignmentsRepo>();

        var app = builder.Build();

        GetRepo.SetServiceProvider(app.Services);

        Task.Run(() => InitSchool.Initialize(app));

        if (!app.Environment.IsDevelopment()) {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        
        app.Run();
    }
}