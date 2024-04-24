using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace nscccoursemap_tillyjay.Models;

public class DiplomaYear
{

    //scalar properties 
    [Key]
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"^Year\s[1-4]$", ErrorMessage = "Title must start with 'Year' followed by a space and a number between 1 and 4.")]
    public string Title { get; set; } = default!;

    [Display(Name = "Diploma")]
    [Required]
    [ForeignKey("DiplomaId")]
    public int DiplomaId { get; set; }


    //nav properties
    //one-to-many relationship with Diploma
    public Diploma Diploma { get; set; } = default!;

    //one-to-many relationship with DiplomaYearSections
    public ICollection<DiplomaYearSection> DiplomaYearSections { get; set; } = [];

}