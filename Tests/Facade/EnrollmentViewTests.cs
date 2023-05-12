using Contoso.Data;
using Contoso.Facade;
using Contoso.Facade.Base;

namespace Contoso.Tests.Facade;
[TestClass] public class EnrollmentViewTests :
    SealedTests<EnrollmentView, DescribedView> {
    [TestMethod] public void CourseIDTest() => isProperty<int>("Course");
    [TestMethod] public void StudentIDTest() => isProperty<int>("Student");
    [TestMethod] public void GradeTest() => isProperty<Grade?>("Grade");
}
