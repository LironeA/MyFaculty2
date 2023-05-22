using System;
using System.Collections.Generic;

namespace MyFaculty2.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public int DegreeId { get; set; }

    public string? UserId { get; set; }

    public virtual ICollection<TeacherToDegreeRelation> TeacherToDegreeRelations { get; set; } = new List<TeacherToDegreeRelation>();

    public virtual ICollection<TeacherToSubjectRelation> TeacherToSubjectRelations { get; set; } = new List<TeacherToSubjectRelation>();
}
