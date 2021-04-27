# RateIt
Hello darkness my old friend im here to push this once again
RateMeMVC
Eleven Fifty Academy Red Badge Final Project

Requirements
Come up with an idea for an application that will use a minimum of 3 custom data tables
Including at least one Foreign Key relationship
Create a wireframe of the application and review it with an instructor
Build out an n-tier structured MVC (think ElevenNote) with the following tiers
Data: This layer houses your classes that relate to the DB (POCOs, Identity, etc)
Models: This layer houses the reusable models for the rest of the layers
Services: This layer is where you’ll have most of your heavy backend logic
WebMVC: This is where the front end (Controllers, Views, Styles, etc) will be
Deploy to Azure
Link to deployed site on your Portfolio
Repository has a README.md associated with the project
Mission Statement
RateMe allows users to view existing reviews for movies, music, and shows as well as add, edit, and delete their own reviews. RateMe displays entertainment details, all reviews, and calculates an average rating based on reviews made on RateMe. RateMe also recommends the best type of entertainment for a user so they never regret the time spent on the site.

Steps to follow for proper implementation
RateMe has 4 classes- Movies, Music, Shows, and Reviews. The review class is connected with the other three classes in order for the for application to work properly. The different classes offer a variety of functionality to the users and help narrow down a user's search.

Users must register and login to enjoy all the features of this MVC. Once logged in, a user has to ability to see all the reviews posted by other users for an existing movie, music, and show. The search functionality is available to users for quick results for a title, while the sort functionality helps users filter the search results to find the entry they are looking for.All the users are authorized to add a new review to an existing entertainment title. If their search yields a title that is non-existent then the user has the option to create a new movie, music, or show entry to post a review.

The use of different attributes and dependency helps users to be redirected to through different pages and experience the right display property. Formatting and pop-up messages are used to guide users with current changes made and the next step to their search. The main motive of RateMe is to help the user search and select entertainment according to their choice and preferences while making the whole experience a pleasant one.

Resources Implemented
ASP.NET MVC 5- Working with Files- https://www.mikesdotnetting.com/article/259/asp-net-mvc-5-with-ef-6-working-with-files
Bind Multiple Moodels on a View- https://www.codeproject.com/Articles/1108855/ways-to-Bind-Multiple-Models-on-a-View-in-MVC
Implementing Uniqueness or Unique Key Attribute- https://www.codeproject.com/Articles/1130342/Best-Ways-of-Implementing-Uniqueness-or-Unique-K
DateTime Issues- https://www.codeproject.com/Tips/1078167/DateTime-Issue-In-MVC
Working with Enums- https://odetocode.com/blogs/scott/archive/2012/09/04/working-with-enums-and-templates-in-asp-net-mvc.aspx
Adding a New Field- https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-aspnet-mvc4/adding-a-new-field-to-the-movie-model-and-table
Implement Search and Sort- https://www.c-sharpcorner.com/UploadFile/219d4d/implement-search-paging-and-sort-in-mvc-5/
Adding Search and Sort- https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application
