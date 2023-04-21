using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra;
public class InstructorsRepo : BaseRepo<Instructor>, IInstructorsRepo {
	public InstructorsRepo(SchoolContext c) : base(c, c.Instructors) { }
	protected internal override IQueryable<Instructor> addAggregates(IQueryable<Instructor> sql)
		=> sql.Include(i => i.OfficeAssignment)
			  .Include(i => i.CourseAssignments)
				.ThenInclude(i => i.Course)
					.ThenInclude(i => i.Department);
	protected internal override async Task<IEnumerable<Instructor>> runSQLAsync() => await sql.ToListAsync();

}
