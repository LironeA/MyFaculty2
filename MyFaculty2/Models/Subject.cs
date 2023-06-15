using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyFaculty2.Models;

public partial class Subject
{
    public int Id { get; set; }
    [Required]
    [DisplayName("Назва")]
    public string Name { get; set; } = null!;
    [Required]
    [DisplayName("Кількість годин")]
    public int NumberOfHours { get; set; }
    [Required]
    [DisplayName("Скорочення")]
    public string Abbreviation { get; set; } = null!;

    public virtual ICollection<GroupToSubjectRelation> GroupToSubjectRelations { get; set; } = new List<GroupToSubjectRelation>();

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    public virtual ICollection<TeacherToSubjectRelation> TeacherToSubjectRelations { get; set; } = new List<TeacherToSubjectRelation>();
}
