namespace Tests;
public abstract class BaseTests<TClass, TBaseClass> : StaticTests {
    protected TClass obj;
    [TestInitialize] public override void TestInitialize() {
        obj = createObj();
        base.TestInitialize();
    }
    protected abstract TClass createObj();
    protected override Type getType() => obj.GetType();
    [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
    [TestMethod] public void IsTypeOfTest() => Assert.IsInstanceOfType(obj, typeof(TClass));
    [TestMethod] public void IsBaseClassTest() => Assert.AreEqual(obj.GetType().BaseType, typeof(TBaseClass));
}
