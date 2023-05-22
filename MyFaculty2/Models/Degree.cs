using System;
using System.Collections.Generic;

namespace MyFaculty2.Models;

public partial class Degree
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TeacherToDegreeRelation> TeacherToDegreeRelations { get; set; } = new List<TeacherToDegreeRelation>();
}
