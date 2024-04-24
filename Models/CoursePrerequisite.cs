using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace nscccoursemap_tillyjay.Models;

public class CoursePrerequisite
{

    //SCALAR PROPERTIES
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("CourseId")]
    public int CourseId { get; set; }

    [Required]
    [ForeignKey("PrerequisiteId")]
    public int PrerequisiteId { get; set; }


    //NAVIGATION PROPERTIES
    //many-to-one relationship with Course
    public Course Course { get; set; } = default!;

    //many-to-one relationship with Course
    public Course Prerequisite { get; set; } = default!;

}