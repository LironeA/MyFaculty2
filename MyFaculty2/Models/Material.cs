using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyFaculty2.Models;

public partial class Material
{
    public int Id { get; set; }
    [Required]
    [DisplayName("Назва матеріалу")]
    public string Name { get; set; } = null!;
    [Required]
    [DisplayName("Посилання")]
    public string Url { get; set; } = null!;
    [Required]
    [DisplayName("Предмет")]
    public int SubjectId { get; set; }

    public virtual Subject? Subject { get; set; } = null!;
}
