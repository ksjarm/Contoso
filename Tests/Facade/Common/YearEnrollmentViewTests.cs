using Contoso.Facade.Common;

namespace Contoso.Tests.Facade.Common;
[TestClass] public class YearEnrollmentViewTests : ClassTests<YearEnrollmentView, object> {
    [TestMethod] public void EnrollmentDateTest() => isProperty<DateTime>(dataType: "Date");
    [TestMethod] public void StudentCountTest() => isProperty<int>();
}