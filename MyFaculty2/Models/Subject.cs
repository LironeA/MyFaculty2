using System;
using System.Collections.Generic;

namespace MyFaculty2.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int NumberOfHours { get; set; }

    public string Abbreviation { get; set; } = null!;

    public virtual ICollection<GroupToSubjectRelation> GroupToSubjectRelations { get; set; } = new List<GroupToSubjectRelation>();

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    public virtual ICollection<TeacherToSubjectRelation> TeacherToSubjectRelations { get; set; } = new List<TeacherToSubjectRelation>();
}
