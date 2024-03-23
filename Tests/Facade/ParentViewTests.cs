using Contoso.Facade;
using Contoso.Facade.Base;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Tests.Facade;
[TestClass] public class ParentViewTests : SealedTests<ParentView, PersonView> {
    [TestMethod] public void PhoneNrTest() => isProperty<int>("Phone Number", DataType.PhoneNumber);
    [TestMethod] public void RelationshipsTest() => isProperty<IEnumerable<StudentView>>("Relationships");
}