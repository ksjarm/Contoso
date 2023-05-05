using Contoso.Data;
using Contoso.Data.Base;

namespace Contoso.Tests.Data.Base;
[TestClass] public class CourseDataTests :
    SealedTests<CourseData, NamedData> {
}