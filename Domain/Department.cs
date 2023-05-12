using Contoso.Data;
using Contoso.Domain.Base;
using Contoso.Domain.BaseRepos;
using Contoso.Domain.Repos;

namespace Contoso.Domain;
public class Department : NamedEntity<DepartmentData> {
    public Department() : this(null) { }
    public Department(DepartmentData d) : base(d) { }
    public decimal Budget => getValue(data.Budget);
    public DateTime StartDate => getValue(data.StartDate);
    public int? InstructorID => getValue(data.InstructorID);
    public Lazy<Instructor> Administrator => new(GetRepo.Item<IInstructorsRepo, Instructor>(InstructorID));
    public Lazy<IEnumerable<Course>> Courses => new(GetRepo.List<ICoursesRepo, Course>(x => x.DepartmentID == ID));
}