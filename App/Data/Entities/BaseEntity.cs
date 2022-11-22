using System.ComponentModel.DataAnnotations;

namespace App.Data;

public class BaseEntity
{
    [Key]
    [Required]
    public Guid Id { get; set; }
}