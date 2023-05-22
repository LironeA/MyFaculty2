using System;
using System.Collections.Generic;

namespace MyFaculty2.Models;

public partial class Status
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<StudentToStatusRelation> StudentToStatusRelations { get; set; } = new List<StudentToStatusRelation>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
