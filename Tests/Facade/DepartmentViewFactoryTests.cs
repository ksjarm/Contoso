using Contoso.Data;
using Contoso.Domain;
using Contoso.Facade;
using Contoso.Facade.Base;

namespace Contoso.Tests.Facade;

[TestClass] public class DepartmentViewFactoryTests 
    : SealedTests<DepartmentViewFactory, BaseViewFactory<DepartmentData, Department, DepartmentView>> { }
