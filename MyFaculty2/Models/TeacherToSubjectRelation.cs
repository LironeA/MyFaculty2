using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyFaculty2.Models;

public partial class TeacherToSubjectRelation
{
    public int Id { get; set; }
    [Required]
    [DisplayName("Викладач")]
    public int TeacherId { get; set; }
    [Required]
    [DisplayName("Предмет")]
    public int SubjectId { get; set; }

    public virtual Subject? Subject { get; set; } = null!;

    public virtual Teacher? Teacher { get; set; } = null!;
}
