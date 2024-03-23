using Contoso.Pages.Constants;

namespace Contoso.Tests.Pages.Constants;
[TestClass]
public class TextsTests : StaticTests {
    protected override Type type => typeof(Texts);
    [TestMethod] public void HomePageTest() => Assert.AreEqual("Home Page", Texts.HomePage);
    [TestMethod] public void StudentBodyStatisticsTest() => Assert.AreEqual("Student Body Statistics", Texts.StudentBodyStatistics);
    [TestMethod] public void PrivacyPolicyTest() => Assert.AreEqual("Privacy Policy", Texts.PrivacyPolicy);
    [TestMethod] public void CoursesTest() => Assert.AreEqual("Courses", Texts.Courses);
    [TestMethod] public void StudentsTest() => Assert.AreEqual("Students", Texts.Students);
    [TestMethod] public void ParentsTest() => Assert.AreEqual("Parents", Texts.Parents);
    [TestMethod] public void DepartmentsTest() => Assert.AreEqual("Departments", Texts.Departments);
    [TestMethod] public void EnrollmentsTest() => Assert.AreEqual("Enrollments", Texts.Enrollments);
    [TestMethod] public void RelationshipsTest() => Assert.AreEqual("Relationships", Texts.Relationships);
    [TestMethod] public void CourseAssignmentsTest() => Assert.AreEqual("Course Assignments", Texts.CourseAssignments);
    [TestMethod] public void OfficeAssignmentsTest() => Assert.AreEqual("Office Assignments", Texts.OfficeAssignments);
    [TestMethod] public void InstructorsTest() => Assert.AreEqual("Instructors", Texts.Instructors);
    [TestMethod] public void EnrollmentYearTest() => Assert.AreEqual("Enrollment year", Texts.EnrollmentYear);

    public static string DeleteQuestion => "Are you sure you want to delete this?";
    [TestMethod] public void EditTest() => Assert.AreEqual("Edit", Texts.Edit);
    [TestMethod] public void IndexTest() => Assert.AreEqual("Index", Texts.Index);
    [TestMethod] public void CreateTest() => Assert.AreEqual("Create", Texts.Create);
    [TestMethod] public void DeleteTest() => Assert.AreEqual("Delete", Texts.Delete);
    [TestMethod] public void SaveTest() => Assert.AreEqual("Save", Texts.Save);
    [TestMethod] public void DetailsTest() => Assert.AreEqual("Details", Texts.Details);
    [TestMethod] public void BackToListTest() => Assert.AreEqual("Back to List", Texts.BackToList);
    [TestMethod] public void DeleteQuestionTest() => Assert.AreEqual("Are you sure you want to delete this?", Texts.DeleteQuestion);
    [TestMethod] public void ErrorTest() => Assert.AreEqual("Error", Texts.Error);
}