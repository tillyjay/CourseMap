using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace nscccoursemap_tillyjay.Models;

public class CourseOffering
{

    //SCALAR PROPERTIES
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("CourseId")]
    public int CourseId { get; set; }


    [ForeignKey("InstructorId")]
    public int? InstructorId { get; set; }

    [Required]
    [ForeignKey("DiplomaYearSectionId")]
    public int DiplomaYearSectionId { get; set; }

    [Required]
    [ForeignKey("SemesterId")]
    public int SemesterId { get; set; }

    [Display(Name = "Is Directed Elective")]
    [DefaultValue(false)] // Set default value to false
    public bool IsDirectedElective { get; set; }


    //NAVIGATION PROPERTIES
    //many-to-one relationship with DiplomaYearSection
    [Display(Name = "Diploma Year Section")]
    public DiplomaYearSection DiplomaYearSection { get; set; } = default!;

    //many-to-one relationship with Semester
    public Semester Semester { get; set; } = default!;
    
    //many-to-one relationship with Course
    public Course Course { get; set; } = default!;

    //many-to-one relationship with Instructor
    public Instructor Instructor { get; set; } = default!;


}