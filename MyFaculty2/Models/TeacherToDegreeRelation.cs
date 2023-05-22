using System;
using System.Collections.Generic;

namespace MyFaculty2.Models;

public partial class TeacherToDegreeRelation
{
    public int Id { get; set; }

    public int TeacherId { get; set; }

    public int DegreeId { get; set; }

    public virtual Degree Degree { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
