using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra;

public class InstructorsRepo : BaseRepo<Instructor>, IInstructorsRepo {
	public InstructorsRepo(SchoolContext c) : base(c, c.Instructors) { }
}
