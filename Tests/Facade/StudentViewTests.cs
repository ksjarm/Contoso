using Contoso.Facade;
using Contoso.Facade.Base;

namespace Contoso.Tests.Facade;
[TestClass] public class StudentViewTests : SealedTests<StudentView, PersonView> {
    [TestMethod] public void EnrollmentDateTest() => isProperty<DateTime>("Enrollment Date");
    [TestMethod] public void EnrollmentsTest() => isProperty<IEnumerable<CourseView>>("Enrollments");
}