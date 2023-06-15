using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyFaculty2.Models;

public partial class Group
{
    public int Id { get; set; }
    [Required]
    [DisplayName("Назва")]
    public string Name { get; set; } = null!;
    [Required]
    [DisplayName("Спеціальність")]
    public int SpecialtyId { get; set; }

    public virtual ICollection<GroupToSubjectRelation>? GroupToSubjectRelations { get; set; }

    public virtual Specialty? Specialty { get; set; } = null!;

    public virtual ICollection<Student>? Students { get; set; } = new List<Student>();
}
