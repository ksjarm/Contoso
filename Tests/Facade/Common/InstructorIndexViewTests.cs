using Contoso.Domain;
using Contoso.Facade.Common;

namespace Contoso.Tests.Facade.Common;
[TestClass] public class InstructorIndexViewTests : ClassTests<InstructorIndexView, object> {
    [TestMethod] public void InstructorsTest() => isProperty<IEnumerable<Instructor>>();
    [TestMethod] public void CoursesTest() => isProperty<IEnumerable<Course>>();
    [TestMethod] public void EnrollmentsTest() => isProperty<IEnumerable<Enrollment>>();
}