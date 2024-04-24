using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace nscccoursemap_tillyjay.Models;

public class Diploma
{

    //scalar properties 
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 10)]
    public string Title { get; set; } = default!;


    //nav properties
    //one-to-many relationship with DiplomaYears
    [Display(Name = "Diploma Years")]
    public ICollection<DiplomaYear> DiplomaYears { get; set; } = []; 
   

}