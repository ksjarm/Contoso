﻿using Contoso.Domain.Base;

namespace Contoso.Domain;
public class CourseAssignment : BaseEntity {
    public int InstructorID { get; set; }
    public int CourseID { get; set; }
    public Instructor? Instructor { get; set; }
    public Course? Course { get; set; }
}
