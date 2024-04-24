using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace nscccoursemap_tillyjay.Models;

public class AdvisingAssignment
{

    //SCALAR PROPERTIES
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Instructor")] 
    public int InstructorId { get; set; }


    [Required]
    [ForeignKey("DiplomaYearSection")]
    public int DiplomaYearSectionId { get; set; }


    // NAVIGATION PROPERTIES
    //many-to-one relationship with Instructor
    public Instructor Instructor { get; set; } = default!;

    //one-to-one relationship with DiplomaYearSection
    [Display(Name = "Diploma Year Section")]
    public DiplomaYearSection DiplomaYearSection { get; set; } = default!;

}