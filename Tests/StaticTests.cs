using Contoso.Aids;
using Contoso.Data;
using System.Diagnostics;
using System.Reflection;

namespace Contoso.Tests;
public abstract class StaticTests {
    protected abstract Type type { get; }
    protected Type testType => GetType();
    [TestMethod] public void IsCorrectTest()
        => Assert.AreEqual(testType.Name.Replace("Tests", ""), type.Name);
    [TestMethod] public void IsTested() {
        var allTests = GetClass.DeclaredMemberNames(testType);
        var allMembers = GetClass.DeclaredMemberNames(type);

        allMembers.RemoveAll("set_", "get_", ".ctor", "value__");

        foreach (var m in allMembers) {
            var mTest = m + "Test";
            if (allTests.Contains(mTest)) continue;
            Assert.Inconclusive($"<{m}> is not tested.");
        }
    }
    private void hasDescription<TEnum>(TEnum e, string description) where TEnum : Enum {
        if (description is null) return;
        var enumType = typeof(TEnum);
        var enumName = Enum.GetName(enumType, e);
        var fieldInfo = enumType.GetField(enumName);
        var descriptionAttribute = fieldInfo.GetCustomAttribute<System.ComponentModel.DescriptionAttribute>(true);
        var attributeDescription = descriptionAttribute?.Description;
        Assert.AreEqual(description, attributeDescription);
    }
    protected void isInterface<T>(bool canWrite = false) {
        var n = propertyName();
        var p = property(n);
        Assert.AreEqual(canWrite, p.CanWrite, nameof(p.CanWrite));
        Assert.AreEqual(true, p.CanRead, nameof(p.CanRead));
        Assert.AreEqual(typeof(T), p.PropertyType, nameof(p.PropertyType));
    }
    protected void IsEnum<T>(T e, int expected, string description) where T : Enum {
        hasDescription(e, description);
        var enumValue = Convert.ToInt32(e);
        Assert.AreEqual(expected, enumValue);
    }
    protected static string propertyName() {
        var s = new StackTrace();
        var m = s.GetFrame(2).GetMethod();
        var n = m.Name;
        return n.Replace("Test", string.Empty);
    }
    protected PropertyInfo property(string name) {
        var p = type.GetProperty(name);
        Assert.IsNotNull(p);
        return p;
    }
}
