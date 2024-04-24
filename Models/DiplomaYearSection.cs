using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace nscccoursemap_tillyjay.Models;

public class DiplomaYearSection
{

    //SCALAR PROPERTIES
    [Key]
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"^Section  [1-9]$")]
    public string Title { get; set; } = default!;

    [Required]
    [ForeignKey("DiplomaYearId")]
    public int DiplomaYearId { get; set; }

  
    [Required]
    [ForeignKey("AcademicYearId")]
    public int AcademicYearId { get; set; }

    [NotMapped] 
    public string FullDiplomaTitle => $"{DiplomaYear?.Diploma?.Title} - {DiplomaYear?.Title}";


    //NAVIGATION PROPERTIES
    //many-to-one relationship with DiplomaYear
    [Display(Name = "Diploma Year")]
    public DiplomaYear DiplomaYear { get; set; } = default!;

    //one-to-many relationship with CourseOfferings
    [Display(Name = "Course Offerings")]
    public ICollection<CourseOffering> CourseOfferings { get; set; } = [];

    //many-to-one relationship with AcademicYear
    [Display(Name = "Academic Year")]
    public AcademicYear AcademicYear { get; set; } = default!;

    //one-to-one relationship with AdvisingAssignment
    [Display(Name = "Advising Assignment")]
    public AdvisingAssignment AdvisingAssignment { get; set; } = default!;
    

}