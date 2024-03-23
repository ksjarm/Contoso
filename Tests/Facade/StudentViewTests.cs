using Contoso.Facade;
using Contoso.Facade.Base;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Tests.Facade;
[TestClass] public class StudentViewTests : SealedTests<StudentView, PersonView> {
    [TestMethod] public void EnrollmentDateTest() => isProperty<DateTime>("Enrollment Date", DataType.Date);
    [TestMethod] public void EnrollmentsTest() => isProperty<IEnumerable<CourseView>>("Enrollments");
}