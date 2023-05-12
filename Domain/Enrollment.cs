using Contoso.Data;
using Contoso.Domain.Base;
using Contoso.Domain.BaseRepos;
using Contoso.Domain.Repos;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Domain;
public sealed class Enrollment : DescribedEntity<EnrollmentData> {
    public Enrollment() : this(null) { }
    public Enrollment(EnrollmentData d) : base(d) { }
    public int CourseID => getValue(data.CourseID);
    public int StudentID => getValue(data.StudentID);
    public Grade? Grade => getValue(data.Grade);
    public Lazy<Student> Student => new(GetRepo.Item<IStudentsRepo, Student>(StudentID));
    public Lazy<Course> Course => new(GetRepo.Item<ICoursesRepo, Course>(CourseID));
}