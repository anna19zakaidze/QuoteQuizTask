# QuoteQuizTask
Sample quote quiz app with vanilla.js, sass, .Net Core Web API,  Entity Framework Core and SQL server

How to run application ? 
1. Start QuoteManagement.API.
    here we can make CRUD operations on quotes.
    connection string with Sql Server is initialized in appsettings.json with the name "QuoteAPIConnectionString".
    in program.cs I'm using UseCors on app , in order to get requests which are originated by QuizAPI.
    applicationUrl is initialized in launchSettings.json.
2. Start QuizAPI .
    This API is not finished. With current implementation, it makes request to QuoteManagement.API for fetching questions for QuoteQuiz game.
    connection string with Sql Server is initialized in appsettings.json with the name "QuizDbConnection".
    in program.cs I'm using UseCors on app , in order to get requests which are originated by QuizGame.
    applicationUrl is initialized in launchSettings.json.
2. Start QuizGame .
    This vanilla.js project is not also finished, it only authenticates user, then is fetching questions with making get request to QuizAPI and validates user    inputs/answers.
