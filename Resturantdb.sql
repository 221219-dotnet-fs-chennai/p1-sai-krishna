CREATE DATABASE ResturantDb;

CREATE TABLE Resturant(
    Id int IDENTITY(1,1),
    [Name] VARCHAR not null,
    [Cuisine] VARCHAR DEFAULT('Unknown'),
    [OpenTime] time,
    [CloseTime] time,
    [Phone] VARCHAR,
    [Webiste] VARCHAR,
    [Email] VARCHAR,
    [Zipcode] VARCHAR
    PRIMARY KEY(Id)
);
ALTER TABLE Resturant alter COLUMN [Zipcode] VARCHAR(6)


CREATE TABLE Users(
    [Username] VARCHAR(50),
    [Password] VARCHAR(50),
    PRIMARY KEY(Username)
);
ALTER TABLE Users alter COLUMN [Username] VARCHAR(50)

CREATE TABLE Reviews(
    Id INT IDENTITY(1,1),
    OverallRating FLOAT not null,
    Comment varchar(100),
    TasteRating int not null,
    AmbienceRating int not null,
    ServiceRating int not null,
    ResturantId int REFERENCES Resturant(Id),
    Username VARCHAR(50) REFERENCES Users(Username),
    PRIMARY KEY(Id)

);
ALTER TABLE Reviews alter COLUMN [ResturantId] VARCHAR(50)


drop table Reviews;
drop table Users;

INSERT into Resturant valuse("McDonanlds","American",)