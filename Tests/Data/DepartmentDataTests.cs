using Contoso.Data;
using Contoso.Data.Base;

namespace Contoso.Tests.Data;
[TestClass] public class DepartmentDataTests :
    SealedTests<DepartmentData, NamedData> {
}
