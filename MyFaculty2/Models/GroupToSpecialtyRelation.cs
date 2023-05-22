using System;
using System.Collections.Generic;

namespace MyFaculty2.Models;

public partial class GroupToSpecialtyRelation
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int SpecialtyId { get; set; }

    public virtual Specialty Specialty { get; set; } = null!;
}
