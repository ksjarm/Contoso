using Contoso.Aids;

namespace Contoso.Tests;
public abstract class StaticTests {
    protected abstract Type type { get; }
    protected Type testType => GetType();
    [TestMethod] public void IsCorrectTest()
        => Assert.AreEqual(testType.Name.Replace("Tests", ""), type.Name);
    [TestMethod] public void IsTested() {
        var allTests = GetClass.DeclaredMemberNames(testType);
        var allMembers = GetClass.DeclaredMemberNames(type);

        allMembers.RemoveAll("set_", "get_", ".ctor");

        foreach (var m in allMembers) {
            var mTest = m + "Test";
            if (allTests.Contains(mTest)) continue;
            Assert.Inconclusive($"<{m}> is not tested.");
        }
    }
}
