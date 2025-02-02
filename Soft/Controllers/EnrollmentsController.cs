﻿using Microsoft.AspNetCore.Mvc;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Soft.Controllers.Common;
using Contoso.Facade;
using Contoso.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Contoso.Soft.Controllers;
public class EnrollmentsController : BaseController<IEnrollmentsRepo, Enrollment, EnrollmentView> {
    private readonly ICoursesRepo courses;
    private readonly IStudentsRepo students;
    private readonly List<Grade> grades;
    public EnrollmentsController(IEnrollmentsRepo r = null, ICoursesRepo c = null, IStudentsRepo s = null) : base(r) {
        courses = c;
        students = s;
        grades = Enum.GetValues(typeof(Grade)).Cast<Grade>().ToList();
    }

    internal const string properties =
        $"{nameof(EnrollmentView.ID)}, " +
        $"{nameof(EnrollmentView.ValidFrom)}, " +
        $"{nameof(EnrollmentView.ValidTo)}, " +
        $"{nameof(EnrollmentView.Description)}, " +
        $"{nameof(EnrollmentView.CourseID)}, " +
        $"{nameof(EnrollmentView.CourseName)}, " +
        $"{nameof(EnrollmentView.StudentID)}, " +
        $"{nameof(EnrollmentView.StudentName)}, " +
        $"{nameof(EnrollmentView.Grade)}";

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(properties)] EnrollmentView v) => await create(toDomain(v));

	[HttpPost, ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(int id, [Bind(properties)] EnrollmentView v) => await edit(id, toDomain(v));

	protected internal override void relatedLists(Enrollment e = null) {
		ViewBag.Courses = courses?.SelectList;
		ViewBag.Students = students?.SelectList;
        ViewBag.Grades = new SelectList(grades);
    }
    protected Enrollment toDomain(EnrollmentView v) => new EnrollmentViewFactory().Create(v);
    protected override EnrollmentView toView(Enrollment v, bool load = false) => new EnrollmentViewFactory().Create(v, load);
}
