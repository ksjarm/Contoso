using Contoso.Data;
using Contoso.Domain.Base;
using Contoso.Domain.BaseRepos;
using Contoso.Domain.Repos;

namespace Contoso.Domain;
public sealed class Relationship : DescribedEntity<RelationshipData> {
    public Relationship() : this(null) { }
    public Relationship(RelationshipData d) : base(d) { }
    public int StudentID => getValue(data.StudentID);
    public int ParentID => getValue(data.ParentID);
    public Lazy<Student> Student => new(GetRepo.Item<IStudentsRepo, Student>(StudentID));
    public Lazy<Parent> Parent => new(GetRepo.Item<IParentsRepo, Parent>(ParentID));
}