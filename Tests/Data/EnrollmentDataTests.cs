using Contoso.Data;
using Contoso.Data.Base;

namespace Contoso.Tests.Data;
[TestClass] public class EnrollmentDataTests :
    SealedTests<EnrollmentData, DescribedData> {
    [TestMethod] public void CourseIDTest() => isProperty<int>();
    [TestMethod] public void StudentIDTest() => isProperty<int>();
    [TestMethod] public void GradeTest() => isProperty<Grade>();
}
