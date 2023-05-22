﻿using System;
using System.Collections.Generic;

namespace MyFaculty2.Models;

public partial class Specialty
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<GroupToSpecialtyRelation> GroupToSpecialtyRelations { get; set; } = new List<GroupToSpecialtyRelation>();

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
