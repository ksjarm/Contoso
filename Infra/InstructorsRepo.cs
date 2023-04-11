using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;

namespace Contoso.Infra;
public class InstructorsRepo : BaseRepo<Instructor>, IInstructorsRepo {
	public InstructorsRepo(SchoolContext c) : base(c, c.Instructors) { }
}
