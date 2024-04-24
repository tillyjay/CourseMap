using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nscccoursemap_tillyjay.CustomValidators;


namespace nscccoursemap_tillyjay.Models;

public class Semester
{

    //SCALAR PROPERTIES
    [Key]
    public int Id { get; set; }

    [Display(Name = "Name")]
    [Required]
    public string Name { get; set; } = default!;

    [Display(Name = "Start Date")]
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime StartDate { get; set; }

    [Display(Name = "End Date")]
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [DateGreaterThan("StartDate")]
    public DateTime EndDate { get; set; }

    [Display(Name = "Academic Year")]
    [Required]
    [ForeignKey("AcademicYearId")]
    public int AcademicYearId { get; set; }


    //NAVIGATION PROPERTIES
    //many-to-one relationship with AcademicYear
    public AcademicYear AcademicYear { get; set; } = default!;

    //one-to-many relationship with CourseOfferings
    public ICollection<CourseOffering> CourseOfferings { get; set; } = [];

}