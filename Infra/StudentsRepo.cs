using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;

namespace Contoso.Infra;

public class StudentsRepo : BaseRepo<Student>, IStudentsRepo {
	public StudentsRepo(SchoolContext c) : base(c, c.Students) { }
}
