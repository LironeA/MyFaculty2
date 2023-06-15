using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyFaculty2.Models;

public partial class GroupToSubjectRelation
{
    public int Id { get; set; }
    [Required]
    [DisplayName("Группа")]
    public int GroupId { get; set; }
    [Required]
    [DisplayName("Предмет")]
    public int SubjectId { get; set; }

    public virtual Group? Group { get; set; } = null!;

    public virtual Subject? Subject { get; set; } = null!;
}
