using Contoso.Domain.Repos;
using Contoso.Domain;
using Contoso.Facade;
using Contoso.Soft.Controllers;
using Contoso.Soft.Controllers.Common;

namespace Contoso.Tests.Soft.Controllers;
[TestClass] public class RelationshipsControllerTests : 
    BaseTests<RelationshipsController, BaseController<IRelationshipsRepo, Relationship, RelationshipView>> {
    protected override RelationshipsController createObj() => new();
}