using Contoso.Data;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra;
public class SchoolContext : DbContext {
	public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }
	public DbSet<CourseAssignmentData> CourseAssignments { get; set; }
	public DbSet<CourseData> Courses { get; set; }
	public DbSet<DepartmentData> Departments { get; set; }
	public DbSet<EnrollmentData> Enrollments { get; set; }
	public DbSet<InstructorData> Instructors { get; set; }
	public DbSet<OfficeAssignmentData> OfficeAssignments { get; set; }
	public DbSet<StudentData> Students { get; set; }
    public DbSet<ParentData> Parents { get; set; }
    public DbSet<RelationshipData> Relationships { get; set; }
    protected override void OnModelCreating(ModelBuilder b) {
        base.OnModelCreating(b);
        InitializeTables(b);
    }
    public static void InitializeTables(ModelBuilder b){
        b.Entity<CourseAssignmentData>().ToTable(nameof(CourseAssignments));
        b.Entity<CourseData>().ToTable(nameof(Courses));
        b.Entity<DepartmentData>().ToTable(nameof(Departments));
        b.Entity<EnrollmentData>().ToTable(nameof(Enrollments));
        b.Entity<InstructorData>().ToTable(nameof(Instructors));
        b.Entity<OfficeAssignmentData>().ToTable(nameof(OfficeAssignments));
        b.Entity<StudentData>().ToTable(nameof(Students));
        b.Entity<ParentData>().ToTable(nameof(Parents));
        b.Entity<RelationshipData>().ToTable(nameof(Relationships));
    }
}