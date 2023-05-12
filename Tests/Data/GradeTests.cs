using Contoso.Data;

namespace Contoso.Tests.Data;
[TestClass] public class GradeTests : StaticTests {
    protected override Type type => typeof(Grade);
    [TestMethod] public void CountTest() => Assert.AreEqual(6, Enum.GetValues<Grade>().Length);
    [TestMethod] public void ATest() => IsEnum(Grade.A, 5, "Excellent");
    [TestMethod] public void BTest() => IsEnum(Grade.B, 4, "Very good");
    [TestMethod] public void CTest() => IsEnum(Grade.C, 3, "Good");
    [TestMethod] public void DTest() => IsEnum(Grade.D, 2, "Satisfactory");
    [TestMethod] public void ETest() => IsEnum(Grade.E, 1, "Poor");
    [TestMethod] public void FTest() => IsEnum(Grade.F, 0, "Failed");
}