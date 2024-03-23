using Contoso.Data;
using Contoso.Data.Base;

namespace Contoso.Tests.Data;
[TestClass] public class CourseAssignmentDataTests : SealedTests<CourseAssignmentData, DescribedData> {
    [TestMethod] public void InstructorIDTest() => isProperty<int>();
    [TestMethod] public void CourseIDTest() => isProperty<int>();
}
