using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyFaculty2.Models;

public partial class Status
{
    public int Id { get; set; }
    [Required]
    [DisplayName("Назва")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Student>? Students { get; set; } = new List<Student>();
}
