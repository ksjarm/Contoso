namespace Contoso.Tests;
public abstract class SealedTests<TClass, TBaseClass> : ClassTests<TClass, TBaseClass> where TClass : new() {
    [TestMethod] public void IsSealed() => Assert.IsTrue(type.IsSealed);
}