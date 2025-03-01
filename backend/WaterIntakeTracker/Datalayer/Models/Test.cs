using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WaterIntakeTracker.DataLayer.Models;

[Table ("demo")]
public class Test
{
    [Key,Required]
    public int Id { get; set; }

    [Required]
    [NotNull]
    public  string Name { get; set; } = default!;
}