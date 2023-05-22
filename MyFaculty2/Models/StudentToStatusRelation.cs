using System;
using System.Collections.Generic;

namespace MyFaculty2.Models;

public partial class StudentToStatusRelation
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int StatusId { get; set; }

    public virtual Status Status { get; set; } = null!;
}
