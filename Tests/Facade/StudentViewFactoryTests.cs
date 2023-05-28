using Contoso.Data;
using Contoso.Domain;
using Contoso.Facade;
using Contoso.Facade.Base;

namespace Contoso.Tests.Facade;

[TestClass] public class StudentViewFactoryTests 
    : SealedTests<StudentViewFactory, PersonViewFactory<StudentData, Student, StudentView>> { }