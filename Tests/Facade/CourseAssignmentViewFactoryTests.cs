using Contoso.Data;
using Contoso.Domain;
using Contoso.Facade;
using Contoso.Facade.Base;

namespace Contoso.Tests.Facade;

[TestClass] public class CourseAssignmentViewFactoryTests 
    : SealedTests<CourseAssignmentViewFactory, BaseViewFactory<CourseAssignmentData, CourseAssignment, CourseAssignmentView>> { }
