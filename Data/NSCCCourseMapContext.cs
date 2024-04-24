using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_tillyjay.Models;


namespace nscccoursemap_tillyjay.Data
{
    public class NSCCCourseMapContext : DbContext
    {
        public NSCCCourseMapContext (DbContextOptions<NSCCCourseMapContext> options)
            : base(options)
        {
        }

        //define our DbSets aka Tables
        public DbSet<Diploma> Diplomas { get; set; } = default!;

        public DbSet<AcademicYear> AcademicYears { get; set; } = default!;

        public DbSet<Instructor> Instructors { get; set; } = default!;

        public DbSet<Course> Courses { get; set; } = default!;

        public DbSet<DiplomaYear> DiplomaYears { get; set; } = default!;

        public DbSet<DiplomaYearSection> DiplomaYearSections { get; set; } = default!;

        public DbSet<Semester> Semesters { get; set; } = default!;

        public DbSet<AdvisingAssignment> AdvisingAssignments { get; set; } = default!;

        public DbSet<CoursePrerequisite> CoursePrerequisites { get; set; } = default!;

        public DbSet<CourseOffering> CourseOfferings { get; set; } = default!;


        // CUSTOM CONFIGURATION WITH FLUENT API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        //MODEL BUILDER CONFIGURATION
        //integrity constraints and validation requirements

            //AdvisingAssignments configuration
                //composite key of InstructorId and DiplomaYearSectionId 
                modelBuilder.Entity<AdvisingAssignment>()
                    .HasIndex(aa => new { aa.InstructorId, aa.DiplomaYearSectionId  })
                    .IsUnique();


            //Course configuration
                modelBuilder.Entity<Course>()
                    .HasIndex(c => c.CourseCode)
                    .IsUnique();


            //CourseOfferings configuration
                //composite key of CourseId, InstructorId, DiplomaYearSectionId, and SemesterId
                modelBuilder.Entity<CourseOffering>()
                    .HasIndex(co => new { co.CourseId, co.InstructorId, co.DiplomaYearSectionId, co.SemesterId })
                    .IsUnique();


            //CoursePrerequisites configuration
                //composite key of CourseId and PrerequisiteId
                modelBuilder.Entity<CoursePrerequisite>()
                    .HasIndex(cp => new { cp.CourseId, cp.PrerequisiteId })
                    .IsUnique();


            //Diploma configuration
                modelBuilder.Entity<Diploma>()
                    .HasIndex(d => d.Title)
                    .IsUnique();
            

            //DiplomaYear configuration
                //composite key of Title and DiplomaId
                modelBuilder.Entity<DiplomaYear>()
                    .HasIndex(dy => new { dy.Title, dy.DiplomaId })
                    .IsUnique();


            //DiplomaYearSections configuration
                //composite key of Title, DiplomaYearId, and AcademicYearId
                modelBuilder.Entity<DiplomaYearSection>()
                    .HasIndex(dys => new { dys.Title, dys.DiplomaYearId, dys.AcademicYearId })
                    .IsUnique();


            //Semester configuration
                modelBuilder.Entity<Semester>()
                    .HasIndex(s => s.Name)
                    .IsUnique();


                //EndDate must be later than StartDate
                modelBuilder.Entity<Semester>()
                    .ToTable("Semesters", t => t.HasCheckConstraint
                    ("CHK_EndDateAfterStartDate", "[EndDate] > [StartDate]"));



                // RECONCILE THE MANY TO MANY RECURSIVE (VERSION 1)
                modelBuilder.Entity<Course>()
                    .HasMany(c => c.Prerequisites)
                    .WithOne(cpr => cpr.Course)
                    .HasForeignKey(cpr => cpr.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.IsPrerequisiteFor)
                .WithOne(cpr => cpr.Prerequisite)
                .HasForeignKey(cpr => cpr.PrerequisiteId);

            // TURN OFF CASCADE DELETE FOR ALL RELATIONSHIPS
            foreach(var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach(var fk in entity.GetForeignKeys()){
                    fk.DeleteBehavior = DeleteBehavior.NoAction;
                }
            }
        }

    }
}