using Contoso.Data;
using Contoso.Domain;
using Contoso.Facade;
using Contoso.Facade.Base;

namespace Contoso.Tests.Facade;

[TestClass] public class InstructorViewFactoryTests 
    : SealedTests<InstructorViewFactory, PersonViewFactory<InstructorData, Instructor, InstructorView>> { }
