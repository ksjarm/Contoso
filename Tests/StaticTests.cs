using System.Reflection;

namespace Tests
{
    public abstract class StaticTests
    {
        protected Type? type;
        [TestInitialize] public virtual void TestInitialize() => type = getType();
        protected abstract Type? getType();
        [TestMethod]
        public void IsTested()
        {
            var allTests = GetType().GetMembers().Select(x => x.Name);
            var allMembers = type.GetMembers(
                 BindingFlags.DeclaredOnly
                | BindingFlags.Public
                | BindingFlags.Instance
                | BindingFlags.Static)
                .Select(x => x.Name)
                .Where(x => !x.StartsWith("get_")
                    || x.StartsWith("set_")
                    || x.StartsWith(".ctor"));
            foreach (var member in allMembers)
            {
                if (allTests.Contains(member + "Test")) continue;
                Assert.Inconclusive($"<{member}> is not tested");
            }
        }
    }
}
