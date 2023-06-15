using Microsoft.Build.Framework;
using NuGet.Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Composition.Convention;

namespace MyFaculty2.Models;

public partial class Teacher
{
    public int Id { get; set; }
    [Required]
    [DisplayName("Ім'я")]
    public string Name { get; set; } = null!;
    [Required]
    [DisplayName("Прізвіще")]
    public string Surname { get; set; } = null!;
    [Required]
    [DisplayName("По батькові")]
    public string LastName { get; set; } = null!;
    [Required]
    [DisplayName("Дата народження")]
    public DateTime DateOfBirth { get; set; }
    [Required]
    [DisplayName("Ступінь")]
    public int DegreeId { get; set; }
    public virtual Degree? Degree { get; set; }

    public string? UserId { get; set; }

    public virtual ICollection<TeacherToSubjectRelation> TeacherToSubjectRelations { get; set; }

    [NotMapped]
    public virtual string PIB{ get{ return $"{Surname} {Name} {LastName}"; } }
}
