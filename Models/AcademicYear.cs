using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace nscccoursemap_tillyjay.Models;

[Index(nameof(Title), IsUnique = true)]
public class AcademicYear
{

    //SCALAR PROPERTIES
    [Key]
    public int Id { get; set; }

    [Display(Name = "Academic Year")]
    [Required]
    [StringLength(20, MinimumLength = 5)]
    public string Title { get; set; } = default!;


    //NAVIGATION PROPERTIES

    //one-to-many relationship with DiplomaYearSections
    public ICollection<DiplomaYearSection> DiplomaYearSections { get; set; } = [];

    //one-to-many relationship with Semester
    public ICollection<Semester> Semesters { get; set; } = [];


}