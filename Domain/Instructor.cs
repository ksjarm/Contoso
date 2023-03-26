﻿using System.ComponentModel.DataAnnotations;

namespace Contoso.Domain;
public class Instructor : Person {
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Hire Date")]
    public DateTime HireDate { get; set; }

    public ICollection<CourseAssignment>? CourseAssignments { get; set; }
    public OfficeAssignment? OfficeAssignment { get; set; }
}