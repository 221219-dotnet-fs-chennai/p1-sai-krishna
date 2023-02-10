CREATE  DATABASE Project0;
CREATE TABLE [Trainer] (
  [Trainer_id] int PRIMARY KEY IDENTITY(1,1),
  [Name] varchar(40)NOT NULL,
  [Gender] varchar,
  [Phone_no] varchar(15)NOT NULL,
  [Email] varchar(40)NOT NULL UNIQUE,
  [Password] varchar(20)NOT NULL,
  [City] varchar(30),
  [State] varchar(30),
  [Pincode] varchar(6),
  [About_me] varchar(100)
);

CREATE TABLE [Users](
  [Email] VARCHAR(40) PRIMARY KEY,
  [Password] VARCHAR(20)NOT NULL,
  [Name] VARCHAR(40)NOT NULL
);


CREATE TABLE [Education] (
  [Trainer_id] int,
  [Institute_name] varchar(50),
  [Degree] varchar(30),
  [Start_date] VARCHAR(7),
  [End_date] VARCHAR(7),
  [CGPA] varchar(10),
  CONSTRAINT [FK_Education.Trainer_id]
    FOREIGN KEY ([Trainer_id])
      REFERENCES [Trainer]([Trainer_id]) ON DELETE CASCADE ON UPDATE CASCADE
);
drop  table Education

CREATE TABLE [Achivements] (
  [Trainer_id] int,
  [Title] varchar(80),
  [Description] varchar(MAX),
  CONSTRAINT [FK_Achivements.Trainer_id]
    FOREIGN KEY ([Trainer_id])
      REFERENCES [Trainer]([Trainer_id]) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE [Experience] (
  [Trainer_id] int,
  [Cmp_name] varchar(30),
  [Role] varchar(30),
  [Start_date] VARCHAR(7),
  [End_date] VARCHAR(7),
  CONSTRAINT [FK_Companies.Trainer_id]
    FOREIGN KEY ([Trainer_id])
      REFERENCES [Trainer]([Trainer_id]) ON DELETE CASCADE ON UPDATE CASCADE
);


CREATE TABLE [Skills] (
  [Trainer_id] int,
  [Skill_name] varchar(25),
  [Description] varchar(MAX),
  CONSTRAINT [FK_Skills.Trainer_id]
    FOREIGN KEY ([Trainer_id])
      REFERENCES [Trainer]([Trainer_id]) ON DELETE CASCADE ON UPDATE CASCADE
);



Select * from Trainer;
Select * from Education;
Select * from Experience;
Select * from Skills;
Select * from Achivements;
select * from Users;

ALTER TABLE Skills 
ADD Skill_id int IDENTITY(1,1);

ALTER TABLE Skills
ADD PRIMARY KEY (Skill_id);

ALTER TABLE Education
ADD Education_id int PRIMARY KEY IDENTITY(1,1);

ALTER TABLE Experience
ADD Experience_id int PRIMARY KEY IDENTITY(1,1);

DELETE from Trainer where Trainer_id>21


ALTER TABLE Achivements
ADD Achivements_id int PRIMARY KEY IDENTITY(1,1);