CREATE DATABASE Company;

CREATE TABLE Department(id int PRIMARY KEY,Name varchar(max),location VARCHAR(max));

CREATE TABLE Employee(id int  IDENTITY(1,1),FirstName varchar(max),LastName varchar (max), ssn varchar(max),deptID int REFERENCES Department(id));

ALTER TABLE Employee
add CONSTRAINT EmployeePrimary_key PRIMARY KEY(id);

Create table EmployeeDetails(
    id int PRIMARY KEY,
    Employeeid int REFERENCES Employee(id),
    Salary FLOAT,
    address1 VARCHAR(max), address2 VARCHAR(max),
    city VARCHAR(max),state VARCHAR(max), country VARCHAR(max));

ALTER TABLE EmployeeDetails
add CONSTRAINT UNIQUE_id UNIQUE(Employeeid);

INSERT into Department VALUES(1,'Technology','Banglore'),(2,'Marketing','Mumbai'),(3,'Sales','Chennai')
INSERT into Employee(FirstName,LastName,ssn,deptID) VALUES ('Tina','Smith','885425',2),('Billy','Joel','224425',2),('Mike','Mayers','456425',1);
INSERT into EmployeeDetails(id,Employeeid,Salary,address1,address2,city,state,country) VALUES
   (1,1,40000,'23rd cross','8th main','Navi Mumbai','Mumbai','India'),
   ( 2,2,30000,'8th cross','1st main','Navi Mumbai','Mumbai','India'),
   ( 3,3,50000,'6th cross','13th main','Banglore','Karnataka','India');

SELECT * from Department;
SELECT * from Employee;
SELECT * from EmployeeDetails;

SELECT * from Employee as e,Department as d
where  d.Name='Marketing' AND e.deptID=d.id

SELECT SUM(ed.Salary) as Salary_Marketing  from Employee as e,Department as d, EmployeeDetails as ed
where  d.Name='Marketing' AND e.deptID=d.id AND e.id=ed.Employeeid

SELECT COUNT(d.id) from Employee as e,Department as d
where e.deptID=d.id
GROUP BY d.id

UPDATE EmployeeDetails
set Salary=Salary+90000
where Employeeid=1;