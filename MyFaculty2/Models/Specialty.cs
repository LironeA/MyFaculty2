using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyFaculty2.Models;

public partial class Specialty
{
    public int Id { get; set; }
    [Required]
    [DisplayName("Назва спеціальності")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Group>? Groups { get; set; } = new List<Group>();
}
