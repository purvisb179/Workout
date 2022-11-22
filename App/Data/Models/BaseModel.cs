using System.ComponentModel.DataAnnotations;

namespace App.Models;

public class BaseModel
{
    [Required]
    public Guid Id { get; set; }
}