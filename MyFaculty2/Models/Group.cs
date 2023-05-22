using System;
using System.Collections.Generic;

namespace MyFaculty2.Models;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int SpecialtyId { get; set; }

    public virtual GroupToSubjectRelation? GroupToSubjectRelation { get; set; }

    public virtual Specialty Specialty { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
