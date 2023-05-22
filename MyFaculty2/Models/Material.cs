using System;
using System.Collections.Generic;

namespace MyFaculty2.Models;

public partial class Material
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public int SubjectId { get; set; }

    public virtual Subject Subject { get; set; } = null!;
}
