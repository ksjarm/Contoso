using Contoso.Data;
using Contoso.Domain.Base;
using Contoso.Domain.BaseRepos;
using Contoso.Domain.Repos;

namespace Contoso.Domain;
public sealed class Parent : Person<ParentData> {
    public Parent() : this(null) { }
    public Parent(ParentData d) : base(d) { }
    public string PhoneNr => getValue(data.PhoneNr);
    //public Lazy<IEnumerable<Relationship>> Relationships
    //    => new(GetRepo.List<IRelationshipsRepo, Relationship>(x => x.ParentID == ID));
}