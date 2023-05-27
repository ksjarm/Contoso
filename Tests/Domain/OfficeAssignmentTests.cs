using Contoso.Data;
using Contoso.Domain;
using Contoso.Domain.Base;

namespace Contoso.Tests.Domain;
[TestClass] public class OfficeAssignmentTests : SealedTests<OfficeAssignment, DescribedEntity<OfficeAssignmentData>> {}