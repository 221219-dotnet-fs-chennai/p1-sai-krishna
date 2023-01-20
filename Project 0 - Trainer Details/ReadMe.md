# <u>Project_0 - Sai Krishna C</u>
## <u>This project name is Find a Trainer Online.</u>
- Agenda is to create an application to add professional trainers details in a database and these trainers are able to upload their profiles, so that recruiters and clients can reach out to them to offer business as well get their team trained on required skill sets.
### <u>This is the first phase of this Project, in this</u> 
- Trainers can SignUp and register their email,if there is already existing details then they can go with the Login
- After loggin in the trainer can perform the following Operations
    - Add, Modify or Delete Personal Details
    - Add, Modify or Delete Skills
    - Add, Modify or Delete Education details
    - Add, Modify or Delete Experiences
    - Add, Modify or Delete Achivements
    - View Profile
    
- Trainer can choose one of these options and Add,Delete,Update and View for each Section.He can also view full profile or delete hos account in the first option


### <u>Technologies Used</u>
- Using Azure data studio for storing tables and performing actions on them.
- Using ADO.NET for connection to database and C# as the middleware


### <u>Project Flow</u>
- To run this project firstly we have to get the connection string and store it in a file for database connection and add the file to gitIgnore file for safety reasons.Next we have to check if our IP Address is registerd in Azure Data Studio or else the connection will fail.
- Once the connection is set then trainer can sign up if he's a new user or can log in if his account is already existing.
- Then he can perform all CURD operations on the tables.
- I have added Regex validation for email, pincode, Start date, End date and Phone number, and also added Exceptopn handiling, so if any given input is wrong or exception is thrown it'll handel it and ask to enter the details again.
- He can also view his whole profile, he can also delete his account then he will be redirected to Welcome page .  


### <u>Contribution</u>
- Firstly I created the Er Diagram to get the basic idea and fields reqired and decided the relationship between them.
- Then created the Tables in the database.
- Then started connection using ado.Net and performed all sql operations then formatted all my Console statemets to make the Trainer Interaction with the console better and added some valodations using Regex.

### <u>Future Enhancements </u>
- In the next phase I would like to have a User table and in that User SignUp and User SignIn and search and trainers based on filtes like Gender, City, Pincode, Skill, etc. I will implement this using LINQ topic which we learnt recently.
- I would like to look into password masking topic and add that also if possible. 
