using Contoso.Aids;

namespace Tests;
public abstract class StaticTests {
    protected Type type;
    [TestInitialize] public virtual void TestInitialize() => type = getType();
    protected abstract Type? getType();
    //[TestMethod] public void IsTested() {
    //    var allMembers = GetClass.DeclaredMemberNames(type);
    //    var allTests = GetClass.DeclaredMemberNames(this);

    //    allMembers.RemoveAll("get_", "set_", ".ctor");

    //    foreach (var m in allMembers) {
    //        if (allTests.Contains(m + "Test")) continue;
    //        Assert.Inconclusive($"<{m}> is not tested");
    //    }
    //}
}
