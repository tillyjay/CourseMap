using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace nscccoursemap_tillyjay.Models;

public class Course
{

    //SCALAR PROPERTIES
    [Key]
    public int Id { get; set; }

    [Display(Name = "Course Code")]
    [Required] 
    [RegularExpression(@"^[A-Z]{4}\s[0-9]{4}$", ErrorMessage = "Course code must consist of four uppercase letters followed by a space and four digits")]
    //four uppercase letters, one space, four digits
    public string CourseCode { get; set; } = default!;


	[Required]
    [StringLength(100, MinimumLength = 5)]
    public string Title { get; set; } = default!;

    //NAVIGATION PROPERTIES

    //many-to-many relationship with Prerequisites
    public ICollection<CoursePrerequisite> Prerequisites { get; set; } = [];

    //many-to-many relationship with Prerequisites
    [Display(Name = "Is Prerequisite For")]
    public  ICollection<CoursePrerequisite> IsPrerequisiteFor { get; set; } = [];

    //one-to-many relationship with CourseOfferings
    public ICollection<CourseOffering> CourseOfferings { get; set; } = [];



}