﻿using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra;
public class StudentsRepo : BaseRepo<Student>, IStudentsRepo {
	public StudentsRepo(SchoolContext c) : base(c, c.Students) { }
    public override string selectTextField => nameof(Student.FullName);
    protected internal override IQueryable<Student> addFilter(IQueryable<Student> s) {
        var v = CurrentFilter;
        return string.IsNullOrWhiteSpace(v) ? base.addFilter(s) :
             s.Where(x => x.Name.Contains(v) ||
               x.FirstMidName.Contains(v) ||
               x.EnrollmentDate.ToString().Contains(v));
    }
    protected internal override IQueryable<Student> сreateSQL() => addAggregates(base.сreateSQL());
    protected internal override IQueryable<Student> addAggregates(IQueryable<Student> sql)
        => sql.Include(e => e.Enrollments).ThenInclude(e => e.Course);
}