using Contoso.Data;
using Contoso.Domain;
using Contoso.Domain.Base;

namespace Contoso.Tests.Domain;
[TestClass] public class CourseAssignmentTests : SealedTests<CourseAssignment, DescribedEntity<CourseAssignmentData>> {

}
