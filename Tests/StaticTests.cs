using Contoso.Aids;
using System.Formats.Asn1;
using System.Reflection;

namespace Tests;
public abstract class StaticTests {
    protected Type type;
    [TestInitialize] public virtual void TestInitialize() => type = getType();
    protected abstract Type? getType();
    [TestMethod] public void IsTested() {
        var allMembers = GetClass.DeclaredMemberNames(type);

        allMembers.RemoveAll("get_", "set_", ".ctor");

        var allTests = GetClass.DeclaredMemberNames(this);

        foreach (var m in allMembers) {
            if (allTests.Contains(m + "Test")) continue;
            Assert.Inconclusive($"<{m}> is not tested");
        }
    }
}
