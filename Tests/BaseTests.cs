using Contoso.Aids;
using System.Diagnostics;
using System.Reflection;

namespace Contoso.Tests;
public abstract class BaseTests<TClass, TBaseClass> : StaticTests {
    protected TClass obj;
    protected override Type type => obj.GetType();
    [TestInitialize] public virtual void TestInitialize() => obj = createObj();
    protected abstract TClass createObj();
    [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
    [TestMethod] public void IsTypeOfTest() => Assert.AreEqual(typeof(TClass), type);
    [TestMethod] public void BaseClassTest() => Assert.AreEqual(typeof(TBaseClass), type.BaseType);
    protected void isNullable<T>() {
        var n = propertyName();
        isReadWrite<T>(n);
        setValue(property(n), null);
    }
    protected void isProperty<T>() {
        var n = propertyName();
        isReadWrite<T>(n);
    }
    private void isReadWrite<T>(string propertyName) {
        var v = GetRandom.Value<T>();
        setValue(property(propertyName), v);
    }
    private PropertyInfo property(string name) {
        var p = type.GetProperty(name);
        Assert.IsNotNull(p);
        return p;
    }
    private void setValue(PropertyInfo pi, dynamic value) {
        pi.SetValue(obj, value);
        Assert.AreEqual(value, pi.GetValue(obj));
    }
    private static string propertyName() {
        var s = new StackTrace();
        var m = s.GetFrame(2).GetMethod();
        var n = m.Name;
        return n.Replace("Test", string.Empty);
    }
}
