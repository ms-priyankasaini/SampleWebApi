# SampleWebApi
Web Api on CRUD operations on Employee Entity

This Web Api is build using Entity Framework and Local Sql Server which contains the employees table.
Below is the script used to create the table..

--DROP SCHEMA IF EXISTS EmpDB;
--CREATE SCHEMA EmpDB;
--USE EmpDB;

select * from employees

/* Table: employees */
CREATE TABLE employees (
  id              INT NOT NULL,
  last_name       VARCHAR(50) ,
  first_name      VARCHAR(50) ,
  email           VARCHAR(50) ,
  job_title       VARCHAR(50) ,
  department      VARCHAR(50) ,
  phone           VARCHAR(25) ,
  city            VARCHAR(50) ,
  state           VARCHAR(50) ,
  country         VARCHAR(50) ,
  PRIMARY KEY (id)
);

insert into employees 
(id, last_name, first_name, email, phone, city, state, country, job_title, department) values 
 (201, 'Harris', 'George', 'gharris0@pagesperso-orange.fr', '1-(210)270-8536','San Antonio', 'Texas', 'United States', 'Administrative Assistant I', 'Toys')
,(202, 'Hayes', 'Rachel', 'rhayes1@si.edu', '1-(971)797-2729', 'Portland', 'Oregon', 'United States', 'Design Engineer', 'Books')
,(203, 'Palmer', 'Anthony', 'apalmer2@posterous.com', '1-(702)984-2108', 'North Las Vegas', 'Nevada', 'United States', 'Health Coach II', 'Toys')
,(204, 'Alvarez', 'Laura', 'lalvarez3@time.com', '1-(518)328-2658', 'Albany', 'New York', 'United States', 'Computer Systems Analyst II', 'Health')
,(205, 'Reynolds', 'Annie', 'areynolds4@nasa.gov', '1-(775)838-2203', 'Reno', 'Nevada', 'United States', 'Senior Quality Engineer', 'Kids')
,(206, 'Henry', 'Joe', 'jhenry5@bbb.org', '1-(682)563-2229','Fort Worth', 'Texas', 'United States', 'Chief Design Engineer', 'Electronics')
,(207, 'Willis', 'Willie', 'wwillis6@berkeley.edu', '1-(317)654-6888',  'Indianapolis', 'Indiana', 'United States', 'Structural Analysis Engineer', 'Shoes')
,(208, 'Lawrence', 'Keith', 'klawrence7@discovery.com', '1-(501)583-8851',  'Little Rock', 'Arkansas', 'United States', 'VP Quality Control', 'Outdoors')
,(209, 'Johnston', 'Tina', 'tjohnston8@alexa.com', '1-(901)128-9976','Memphis', 'Tennessee', 'United States', 'Assistant Media Planner', 'Electronics');

--------------End of Employee Table----- 

