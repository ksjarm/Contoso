using Contoso.Data;
using Contoso.Domain.Base;
using Contoso.Domain.BaseRepos;
using Contoso.Domain.Repos;

namespace Contoso.Domain;
public sealed class OfficeAssignment : DescribedEntity<OfficeAssignmentData> {
    public OfficeAssignment() : this(null) { }
    public OfficeAssignment(OfficeAssignmentData d) : base(d) { }
    public int InstructorID => getValue(data.InstructorID);
    public string Location => getValue(data.Location);
    public Lazy<Instructor> Instructor => new(GetRepo.Item<IInstructorsRepo, Instructor>(InstructorID));
}