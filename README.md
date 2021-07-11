# WeatherApplicationRepo

COMPARISON AND ASPECTS OF PROGRAM

Comparison: task requirements and what was done.
What was done:
- Add weather condition for certain city at certain point of time.
- Update weather condition for certain city at certain point of time.
- Archive weather condition for certain city for certain period of time - archived data should not be used in statistical calculations. I did archivation by uploading json file and recreating zip file. For tracking archived file I added IsArchived property.
- Retrieve history of weather conditions for a selected city.
- Retrieve current weather conditions for a selected city and statistical information - average, max and min value of each weather unit of measure.
- support storing historical temperature data per city and limited count of statistical information.
- Data stored in SQL DB, Entity Framework Core in use. Created data models with cascade delete behavior.
- Application consists of following 3 layers: Domain Layer, Infrastructure Layer, UserInterface Layer.
- Solution holds current weather conditions for a selected city and statistical information in cache (I set 2 minutes).
- Application should be possible to launch from Visual Studio in a one click with only change of DB connection string. Seed data should be populated by application so no need to run extra sql script is required. The only place where I indicated a connection string is appsettings file.
- Returns of controller according to Microsoft guidelines. I picked long controller names to make it more understandable. Also added little comments.
- In addition to the task, added additional methods.
- Completed in 3 working days.

What was not done:
- Temperature in Celsius degrees with timestamp in database. In models I set separate properties.

Aspects of program:
The program is seeding database. During application start database sets:
- Cities: Kyiv (CityId = 1), Kharkiv (CityId = 2), Odessa (CityId = 3). All cities have AllowedNumberOfStatisticalModels = 3.
- Weather models (6 items for each city).
5 items have date from 2021/07/05 to 2021/07/07 (inclusive both) and 1 item has DateTime.Now date to check current conditions.

Questions:
- Is it better to create request/response class model with only one property or not create class and leave method with simple parameter?
- Is it good to make try/catch in controller class in order to reduce dependency with repository class?

Will be glad to hear any recommendations/ideas regarding this project)

Thank you for attention and interesting task)
