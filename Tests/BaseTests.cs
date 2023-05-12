﻿using Contoso.Aids;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    protected void isNullable<T>(string displayName = null) {
        var n = propertyName();
        hasDisplayName(n, displayName);
        isReadWrite<T>(n);
        setValue(property(n), null);
    }
    protected void isProperty<T>(string displayName = null) {
        var n = propertyName();
        hasDisplayName(n, displayName);
        isReadWrite<T>(n);
    }
    private void hasDisplayName(string n, string displayName) {
        if (displayName is null) return;
        var p = property(n);
        var a = p.GetCustomAttribute<DisplayNameAttribute>(true);
        Assert.AreEqual(displayName, a?.DisplayName); 
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
