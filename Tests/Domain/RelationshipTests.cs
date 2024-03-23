using Contoso.Data;
using Contoso.Domain;
using Contoso.Domain.Base;

namespace Contoso.Tests.Domain;
[TestClass] public class RelationshipTests : SealedTests<Relationship, DescribedEntity<RelationshipData>> { }