using Contoso.Data;
using Contoso.Data.Base;

namespace Contoso.Tests.Data;
[TestClass] public class OfficeAssignmentDataTests :
    SealedTests<OfficeAssignmentData, DescribedData> {
    [TestMethod] public void InstructorIDTest() => isProperty<int>();
    [TestMethod] public void LocationTest() => isNullable<string>();
}
