using Contoso.Facade.Common;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Tests.Facade.Common;
[TestClass] public class YearEnrollmentViewTests : ClassTests<YearEnrollmentView, object> {
    [TestMethod] public void EnrollmentDateTest() => isProperty<DateTime>(dataType: DataType.Date);
    [TestMethod] public void StudentCountTest() => isProperty<int>();
}