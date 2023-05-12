using Contoso.Data;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;

namespace Contoso.Infra;
public class StudentsRepo : BaseRepo<Student, StudentData>, IStudentsRepo {
	public StudentsRepo(SchoolContext c) : base(c, c.Students) { }
    public override string selectTextField => nameof(StudentData.Name);
    protected internal override IQueryable<StudentData> addFilter(IQueryable<StudentData> s) {
        var v = CurrentFilter;
        return string.IsNullOrWhiteSpace(v) ? base.addFilter(s) :
             s.Where(x => x.Name.Contains(v) ||
               x.FirstName.Contains(v) ||
               x.Gender.ToString().Contains(v) ||
               x.EnrollmentDate.ToString().Contains(v) ||
               x.ValidFrom.ToString().Contains(v) ||
               x.ValidTo.ToString().Contains(v) ||
               x.Description.Contains(v) ||
               x.Code.Contains(v));
    }
    protected override StudentData toData(Student o) => o?.Data;
    protected override Student toDomain(StudentData d) => new(d);
}