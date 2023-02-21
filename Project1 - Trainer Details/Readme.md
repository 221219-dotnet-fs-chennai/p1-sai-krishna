# <u>Project_1 - Sai Krishna C</u>
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
- Using ASP.NET I created API's which can be consumed by the client/user.
- HTML, CSS, Bootstrap and JavaScript for front-end for better user interaction


### <u>Project Flow</u>
- The user can visit my website see some features of the website and sign up , if he already has an account he can sign in and perform all actions like add, delete, update is education,skills,experience, achivements and personel details.
- The flow of the project is that the a request is sent form website it goes to the controllers and then controller calls the logic interface which then maps the 
   models data to entities and call the Repo interface in entites layer on which actions are performed and it returns a value to business logic and then the
   business logic maps back the result into entities to models type and returns the value to controllers which the returs a respons to the webpage 
   and then the user can know if the request is completed sucesfully or not .


### <u>Contribution</u>
- I have used DB First approach and scaffolded the tables which I had created in Project 0.
- Then created 4 main layers- Business Logic with mappers that map modeels to entities and vice versa,
- Then a entities layer with all the entity models and db context file,
- And the program starts from the Services layer which had the controllers which is used to coller the business logic to perform operations on request and send back the response.
- Then he can perform all CURD operations on the tables using API's with swagger or postman.
- Aditionally there is also a testing layer to perform unit testing with Xunit and Nunit.
- Then I have created a UI layer with HTML,CSS, Botststrap completely independent of the backend code in which the trainer can perform all operations with a better user interaction interface and sccesing the apis using Javascript.
- I have also added filtering options in the website to search trainers by gender, city, state, and Skill.
- He can also view his whole profile, he can also delete his account then he will be redirected to Welcome page . 

### <u>Future Enhancements </u>
- In the future I would like to make the user interface more user friendly and faster using asyncronous programming methods.
