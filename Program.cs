using Microsoft.EntityFrameworkCore;
using nscccoursemap_tillyjay.Data;
using nscccoursemap_tillyjay.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

//add services to the container.
builder.Services.AddRazorPages(options =>
{

    //authorization for all pages by default
    options.Conventions.AuthorizeFolder("/AcademicYears");
    options.Conventions.AuthorizeFolder("/AdvisingAssignments");
    options.Conventions.AuthorizeFolder("/CourseOfferings");
    options.Conventions.AuthorizeFolder("/CoursePrerequisites");
    options.Conventions.AuthorizeFolder("/Courses");
    options.Conventions.AuthorizeFolder("/Diplomas");
    options.Conventions.AuthorizeFolder("/DiplomaYears");
    options.Conventions.AuthorizeFolder("/DiplomaYearSections");
    options.Conventions.AuthorizeFolder("/Instructors");
    options.Conventions.AuthorizeFolder("/Semesters");
    
    //allow anonymous access to the index and details pages
    options.Conventions.AllowAnonymousToPage("/AcademicYears/Index");
    options.Conventions.AllowAnonymousToPage("/AcademicYears/Details");
    options.Conventions.AllowAnonymousToPage("/AdvisingAssignments/Index");
    options.Conventions.AllowAnonymousToPage("/AdvisingAssignments/Details");
    options.Conventions.AllowAnonymousToPage("/CourseOfferings/Index");
    options.Conventions.AllowAnonymousToPage("/CourseOfferings/Details");
    options.Conventions.AllowAnonymousToPage("/CoursePrerequisites/Index");
    options.Conventions.AllowAnonymousToPage("/CoursePrerequisites/Details");
    options.Conventions.AllowAnonymousToPage("/Courses/Index");
    options.Conventions.AllowAnonymousToPage("/Courses/Details");
    options.Conventions.AllowAnonymousToPage("/Diplomas/Index");
    options.Conventions.AllowAnonymousToPage("/Diplomas/Details");
    options.Conventions.AllowAnonymousToPage("/DiplomaYears/Index");
    options.Conventions.AllowAnonymousToPage("/DiplomaYears/Details");
    options.Conventions.AllowAnonymousToPage("/DiplomaYearSections/Index");
    options.Conventions.AllowAnonymousToPage("/DiplomaYearSections/Details");
    options.Conventions.AllowAnonymousToPage("/Instructors/Index");
    options.Conventions.AllowAnonymousToPage("/Instructors/Details");
    options.Conventions.AllowAnonymousToPage("/Semesters/Index");
    options.Conventions.AllowAnonymousToPage("/Semesters/Details");
});



//SqlServer
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<NSCCCourseMapContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DevelopmentDB_SqlServer")));

    builder.Services.AddDbContext<IdentityContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DevelopmentDB_SqlServer")));
}
else
{
    builder.Services.AddDbContext<NSCCCourseMapContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionDB")));

    builder.Services.AddDbContext<IdentityContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionDB")));
}

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<IdentityContext>();



var app = builder.Build();

//create a scope to get an instance of the database context
//commented out because data already seeded
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

//configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
