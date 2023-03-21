using Contoso.Domain;
using Contoso.Soft.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Domain {
    [TestClass] public class CourceTests : ClassTests<Course, object> {
        [TestMethod] public void CourseIDTest() {
            var i = new Random().Next();
            obj.CourseID = i;
            Assert.AreEqual(i, obj.CourseID);
        }
    }
    public abstract class ClassTests<TClass, TBaseClass> : BaseTests<TClass, TBaseClass> where TClass : new() {
        protected override TClass createObj() => new();
    }
    public abstract class BaseTests<TClass, TBaseClass> : StaticTests{
        protected TClass? obj;
        [TestInitialize] public override void TestInitialize() {
            obj = createObj();
            base.TestInitialize();
        }
        protected abstract TClass createObj();
        protected override Type getType() => obj.GetType();
        [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
        [TestMethod] public void IsTypeOfTest() => Assert.IsInstanceOfType(obj, typeof(TClass));
        [TestMethod] public void IsBaseClass() => Assert.AreEqual(obj.GetType().BaseType, typeof(TBaseClass));
    }
    public abstract class StaticTests
    {
        protected Type? type;
        [TestInitialize] public virtual void TestInitialize() => type = getType();
        protected abstract Type? getType();
        [TestMethod] public void IsTested() {
            var allTests = this.GetType().GetMembers().Select(x => x.Name);
            var allMembers = type.GetMembers()
                .Select(x => x.Name)
                .Where(x => ! x.StartsWith("get_") 
                    || x.StartsWith("set_")
                    || x.StartsWith(".ctor"));
            foreach(var member in allMembers)
            {
                if (allTests.Contains(member + "Test")) continue;
                Assert.Inconclusive($"<{member}> is not tested");
            }
        }
    }
}
