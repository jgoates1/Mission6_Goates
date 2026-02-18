using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Goates.Models;

public class Movie
{
    [Key]
    public int MovieId { get; set; }

    //foreignkeyrelationship
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    [Required(ErrorMessage = "Please enter a title")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Please enter a Valid Year")]
    [Range(1888, 2026, ErrorMessage = "Year must be 1888 or later")]
    public int Year { get; set; }
    
    public string? Director { get; set; }
    
    public string? Rating { get; set; }
    [Required(ErrorMessage = "Edited is required")]
    public bool? Edited { get; set; }

    public string? LentTo { get; set; }
    [Required(ErrorMessage = "Copied To Plex is required")]
    public bool CopiedToPlex { get; set; }

    [StringLength(25)]
    public string? Notes { get; set; }
}