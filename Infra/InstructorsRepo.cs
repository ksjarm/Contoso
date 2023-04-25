using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra;
public class InstructorsRepo : BaseRepo<Instructor, Instructor>, IInstructorsRepo {
	public InstructorsRepo(SchoolContext c) : base(c, c.Instructors) { }
    public override string selectTextField => nameof(Instructor.FullName);
    protected internal override IQueryable<Instructor> addAggregates(IQueryable<Instructor> sql)
		=> sql.Include(i => i.OfficeAssignment)
			  .Include(i => i.CourseAssignments)
				.ThenInclude(i => i.Course)
					.ThenInclude(i => i.Department);
	protected internal override async Task<IEnumerable<Instructor>> runSQLAsync() => await sql.ToListAsync();
    protected override Instructor toDomain(Instructor d) => d;

    protected override Instructor toData(Instructor o) => o;
}
