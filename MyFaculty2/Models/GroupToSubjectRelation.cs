using System;
using System.Collections.Generic;

namespace MyFaculty2.Models;

public partial class GroupToSubjectRelation
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int SubjectId { get; set; }

    public virtual Group IdNavigation { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
