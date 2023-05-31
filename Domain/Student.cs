using Contoso.Data;
using Contoso.Domain.Base;
using Contoso.Domain.BaseRepos;
using Contoso.Domain.Repos;

namespace Contoso.Domain;
public sealed class Student : Person<StudentData> {
    public Student() : this(null) { }
    public Student(StudentData d) : base(d) { }
    public DateTime EnrollmentDate => getValue(data.EnrollmentDate);
    public Lazy<IEnumerable<Enrollment>> Enrollments
        => new(GetRepo.List<IEnrollmentsRepo, Enrollment>(x => x.StudentID == ID));
    //public Lazy<IEnumerable<Relationship>> Relationships
    //    => new(GetRepo.List<IRelationshipsRepo, Relationship>(x => x.StudentID == ID));
}