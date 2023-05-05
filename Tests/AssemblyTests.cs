using System.Reflection;

namespace Contoso.Tests;
public class AssemblyTests {
    private string testsSpace => testType.Namespace;
    private string nameSpace => testsSpace.Replace("Tests.", string.Empty);
    private Type testType => GetType();
    private Assembly testAssembly => testType.Assembly;
    private Assembly typeAssembly => Assembly.Load(nameSpace);
    private List<string> tests => getTypes(testAssembly, isThisTest).ToList();
    private IEnumerable<string> types => getTypes(typeAssembly, isThisType);
    [TestMethod]
    public void IsTested() =>
        notTested(types.Where(t => !tests.Contains(toTestClass(t))).FirstOrDefault());
    private static void notTested(string s) {
        if (s is not null) Assert.Inconclusive($"Class <{s}> is not tested");
    }
    private string toTestClass(string s) => $"{s.Replace(nameSpace, testsSpace)}Tests";
    private static IEnumerable<string> getTypes(Assembly a, Func<string, bool> predicate)
        => a.GetTypes().Select(x => x.FullName).Where(predicate);
    private bool isThisTest(string s) => s.StartsWith(testsSpace)
            && !s.EndsWith(testType.FullName);
    private bool isThisType(string s) => s.StartsWith(nameSpace);
}