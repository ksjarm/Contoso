using Contoso.Domain;
using Contoso.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra;

public class SchoolContext : DbContext {
	public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }
	public DbSet<Course> Courses { get; set; }
	public DbSet<Enrollment> Enrollments { get; set; }
	public DbSet<Student> Students { get; set; }
	public DbSet<Department> Departments { get; set; }
	public DbSet<Instructor> Instructors { get; set; }
	public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
	public DbSet<CourseAssignment> CourseAssignments { get; set; }
    protected override void OnModelCreating(ModelBuilder b) {
        base.OnModelCreating(b);
        InitializeTables(b);
    }
    public static void InitializeTables(ModelBuilder b){
        b.Entity<Student>().ToTable(nameof(Students));
        b.Entity<Course>().ToTable(nameof(Courses));
        b.Entity<Enrollment>().ToTable(nameof(Enrollments));
        b.Entity<Department>().ToTable(nameof(Departments));
        b.Entity<Instructor>().ToTable(nameof(Instructors));
        b.Entity<OfficeAssignment>().ToTable(nameof(OfficeAssignments));
        b.Entity<CourseAssignment>().ToTable(nameof(CourseAssignments));
    }
}