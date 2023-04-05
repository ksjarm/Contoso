using Contoso.Domain;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra;

public class SchoolContext : DbContext
{
	public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
	{
	}

	public DbSet<Course> Courses { get; set; }
	public DbSet<Enrollment> Enrollments { get; set; }
	public DbSet<Student> Students { get; set; }
	public DbSet<Department> Departments { get; set; }
	public DbSet<Instructor> Instructors { get; set; }
	public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
	public DbSet<CourseAssignment> CourseAssignments { get; set; }
	public DbSet<Person> People { get; set; }
    protected override void OnModelCreating(ModelBuilder b) {
        base.OnModelCreating(b);
        InitializeTables(b);
    }
    public static void InitializeTables(ModelBuilder b){
		b.Entity<Course>().ToTable("Course");
		b.Entity<Enrollment>().ToTable("Enrollment");
		b.Entity<Student>().ToTable("Student");
		b.Entity<Department>().ToTable("Department");
		b.Entity<Instructor>().ToTable("Instructor");
		b.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
		b.Entity<CourseAssignment>().ToTable("CourseAssignment");
		b.Entity<Person>().ToTable("Person");
		b.Entity<CourseAssignment>()
			.HasKey(c => new { c.CourseID, c.InstructorID });
	}
}