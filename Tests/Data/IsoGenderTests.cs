using Contoso.Data;

namespace Contoso.Tests.Data;
[TestClass] public class IsoGenderTests : StaticTests {
    protected override Type type => typeof(IsoGender);
    [TestMethod] public void CountTest() => Assert.AreEqual(4, Enum.GetValues<IsoGender>().Length);
    [TestMethod] public void NotKnownTest() => IsEnum(IsoGender.NotKnown, 0, "Not Known");
    [TestMethod] public void MaleTest() => IsEnum(IsoGender.Male, 1, "Male");
    [TestMethod] public void FemaleTest() => IsEnum(IsoGender.Female, 2, "Female");
    [TestMethod] public void NotApplicableTest() => IsEnum(IsoGender.NotApplicable, 9, "Not Applicable");
}