using Contoso.Aids;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    protected void isNullable<T>(string displayName = null) {
        var n = propertyName();
        hasDisplayName(n, displayName);
        isReadWrite<T>(n);
        setValue(property(n), null);
    }
    protected void isProperty<T>(string displayName = null, string dataType = null) {
        var n = propertyName();
        hasDisplayName(n, displayName);
        hasDataType(n, dataType);
        isReadWrite<T>(n);
    }
    protected void isReadable<T>(string displayName = null) {
        var n = propertyName();
        hasDisplayName(n, displayName);
        var propertyInfo = property(n);
        var value = propertyInfo.GetValue(obj);
        Assert.IsNotNull(value);
        Assert.AreEqual(typeof(T), value.GetType());
    }
    private void hasDisplayName(string n, string displayName) {
        if (displayName is null) return;
        var p = property(n);
        var a = p.GetCustomAttribute<DisplayNameAttribute>(true);
        Assert.AreEqual(displayName, a?.DisplayName); 
    }
    private void hasDataType(string n, string dataType) {
        if (dataType is null) return;
        var p = property(n);
        var a = p.GetCustomAttributes<DataTypeAttribute>(true).FirstOrDefault();
        Assert.IsNotNull(a);
        var actualDataType = a.DataType.ToString();
        Assert.AreEqual(dataType, actualDataType);
    }
    private void isReadWrite<T>(string propertyName) {
        var v = GetRandom.Value<T>();
        setValue(property(propertyName), v);
    }
    private void setValue(PropertyInfo pi, dynamic value) {
        pi.SetValue(obj, value);
        Assert.AreEqual(value, pi.GetValue(obj));
    }
}