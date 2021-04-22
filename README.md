**Introduction**

This repository consists of 3 projects, ApplicationLayer is a web API project and DAL is a Class Library. The ApplicationLayer porject references the DAL project which interacts with the database. The PresentationLayer project is an Angular project which makes API calls to the ApplicationLayer Project

**How to run the project**

1. Download ZIP
2. Using SQL Server Management, execute the script "AngularProjectSkillsScript.sql" located in DAL project in the folder "DBScripts" - This will create a database with tables and stored procedures. NB: the data is not included.
3. Update the connectionStrings in "web.config" file (located in ApplicationLayer project) on line 65 with your SQL Server name and credentilas if applicable.
4. Clean and rebuild the "AngularProjectSkillsAssessment" solution 
5. Open PresentationLayer/main folder and run the angular project
6. If you're getting errors, please run this command first - npm install --save-dev @angular-devkit/build-angular
7. NB: The ApplicationLayer project has to run while you're running the Angular project so that you will be able to see the data.

Please contact me for further assistance
