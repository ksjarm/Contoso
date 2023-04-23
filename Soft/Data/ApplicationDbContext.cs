using Contoso.Infra;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Contoso.Domain;

namespace Contoso.Soft.Data;
public class ApplicationDbContext : IdentityDbContext {

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
    protected override void OnModelCreating(ModelBuilder b) {
        base.OnModelCreating(b);
        initializeTables(b);
    }
    private static void initializeTables(ModelBuilder b) => SchoolContext.InitializeTables(b);
    public DbSet<Contoso.Domain.CourseAssignment> CourseAssignment { get; set; }
}
