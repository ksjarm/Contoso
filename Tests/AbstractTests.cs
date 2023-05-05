using Tests;

namespace Contoso.Tests {
    public class AbstractTests<TClass, TBaseClass> :
        ClassTests<TClass, TBaseClass> where TClass : new() {
        [TestMethod] public void IsAbstract() => Assert.Inconclusive();
    }
}
