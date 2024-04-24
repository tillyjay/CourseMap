# Course Map

## College Course Map Application
This project is a college course map built with C# and ASP.net. Based on ERD specifications, I created model classes and setting up database context for the database generation. Once seeded added DB integrity constraints and validation requirements to the models. After I scaffoled pages for each model I completed page alterations such as, modify the default get query so that courses are displayed by Course Code in ascending order, as well as decorating the columns. The next step was adding User capability, by adding code to the pages so that they are only accessible by a logged in user and forces you to the login page if the user is not logged in. Finally, upon finishing up some added page functionality I deployed my application to Azure.

 ## Features 
- Register user capability
- Login user capability
- View all college course data in various categories (ex. Academic Years)
- Complete CRUD functionality for all categories
- View details of specific category instance

## Technologies Used
- C#
- ASP.NET
- Azure
- Bootstrap
 
## Lessons Learned
- This was my first experience with C# and ASP.NET so it was great to get a taste of this language and framework.
- I practiced my ability to create models from an ERD along with navigation properities, and setting up the database context class.
- I learned about migrations and their functionality in creating a database.
- I worked on adding data annotations, database integrity and validation requirements.
- Once my models were set up to spec I scaffoled out pages using ASP.NET.
- I learned how to make page alterations by adjusting queries in my pages to display specific data in a specific fashion. I also adjusted the output of the HTML for the CRUD pages.

## Future Improvements 
- As someone who loves styling I would greatly improve the styling of the pages. Adjust all the links, improve spacing, and make better use of Bootstrap.
- Maybe add an prompt depending on the academic year to input the most recent year's course map information.

#Images 
## Starting ERD 
![Screenshot 2024-04-24 130016](https://github.com/tillyjay/CourseMap/assets/97525044/aa70e8e9-b7f0-46ce-ab7d-25d07e559255)

## Course Map Landing Page
![Screenshot 2024-04-24 123930](https://github.com/tillyjay/CourseMap/assets/97525044/4ee2fd19-0861-44b5-82ee-9e99ec122bf2)

## Register Page 
![Screenshot 2024-04-24 124010](https://github.com/tillyjay/CourseMap/assets/97525044/96ad0445-c22d-4684-9d1d-a246bf3520b2)

## Category Example (Academic Years)
![Screenshot 2024-04-24 124301](https://github.com/tillyjay/CourseMap/assets/97525044/9b97b7a1-6a41-4e63-b0f7-ff87f42b2849)

## Category Details 
![Screenshot 2024-04-24 124322](https://github.com/tillyjay/CourseMap/assets/97525044/234c1fee-28cc-4f50-affe-0a8d98aca94e)

## Example of Query Manipulation
![image](https://github.com/tillyjay/CourseMap/assets/97525044/e03b5dbe-c097-4ccf-ba2a-a43abf55cb11)




