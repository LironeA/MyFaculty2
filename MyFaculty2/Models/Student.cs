using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFaculty2.Models;

public partial class Student
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
    [DisplayName("Група")]
    public int GroupId { get; set; }
    [Required]
    [DisplayName("Статус")]
    public int StatusId { get; set; }

    public string? UserId { get; set; }

    public virtual Group? Group { get; set; } = null!;
    public virtual Status? Status { get; set; } = null!;

    [NotMapped]
    public virtual string PIB { get { return $"{Surname} {Name} {LastName}"; } }
}
