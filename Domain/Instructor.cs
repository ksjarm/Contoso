using System.ComponentModel.DataAnnotations;
using Contoso.Data;
using Contoso.Domain.Base;
using Contoso.Domain.BaseRepos;
using Contoso.Domain.Repos;

namespace Contoso.Domain;
public sealed class Instructor : Person<InstructorData> {
    public Instructor() : this(null) { }
    public Instructor(InstructorData d) : base(d) { }
    public DateTime HireDate => getValue(data.HireDate);
    public Lazy<IEnumerable<CourseAssignment>> CourseAssignments
        => new(GetRepo.List<ICourseAssignmentsRepo, CourseAssignment>(x => x.InstructorID == ID));
    public Lazy<OfficeAssignment> OfficeAssignment
        => new(GetRepo
            .List<IOfficeAssignmentsRepo, OfficeAssignment>(x => x.InstructorID == ID)
            .FirstOrDefault());
}