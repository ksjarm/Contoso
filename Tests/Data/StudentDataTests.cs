using Contoso.Data;
using Contoso.Data.Base;

namespace Contoso.Tests.Data;
[TestClass] public class StudentDataTests :
    SealedTests<StudentData, PersonData> {
}