using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyFaculty2.Models;

public partial class Degree
{
    public int Id { get; set; }

    [Required]
    [DisplayName("Назва ступені")]
    public string Name { get; set; } = null!;

    public virtual List<Teacher>? Teachers { get; set; }
}
