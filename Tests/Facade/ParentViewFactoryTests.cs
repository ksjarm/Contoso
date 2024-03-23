using Contoso.Data;
using Contoso.Domain;
using Contoso.Facade;
using Contoso.Facade.Base;

namespace Contoso.Tests.Facade;
[TestClass] public class ParentViewFactoryTests 
    : SealedTests<ParentViewFactory, PersonViewFactory<ParentData, Parent, ParentView>> { }