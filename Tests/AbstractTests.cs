namespace Contoso.Tests; 
public abstract class AbstractTests<TClass, TBaseClass> : BaseTests<TClass, TBaseClass> {
    protected override Type type => obj.GetType().BaseType;
    [TestMethod] public void IsAbstract() => Assert.IsTrue(type.IsAbstract);
}