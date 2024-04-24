using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace nscccoursemap_tillyjay.Models;

public class Instructor
{

    //SCALAR PROPERTIES
    [Key]
    public int Id { get; set; }

    [Display(Name = "First Name")]
    [Required, StringLength(80)]
    public string FirstName { get; set; } = default!;

    [Display(Name = "Last Name")]
    [Required, StringLength(80)]
    public string LastName { get; set; } = default!;

    [Display(Name = "Full Name")]
    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";


    //NAVIGATION PROPERTIES
    //one-to-many relationship with CourseOffering
    public ICollection<CourseOffering> CourseOfferings { get; set; } = [];

    //one-to-many relationship with AdvisingAssignment
    [Display(Name = "Advising Assignments")]
    public ICollection<AdvisingAssignment> AdvisingAssignments { get; set; } = [];

}