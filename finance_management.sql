create database finance_management

create table Users(
user_id int primary key identity,
username varchar(200),
password varchar(200),
email varchar(max))

create table Expenses(
expense_id int primary key identity,
user_id int,
amount money,
category_id int,
date date,
description varchar(max),
constraint fk_uid foreign key (user_id) references Users(user_id),
constraint fk_cid foreign key (category_id) references ExpenseCategories(category_id))

create table ExpenseCategories(
category_id int primary key identity,
category_name varchar(200))

select * from Users


INSERT INTO Users (username, password, email) VALUES
('kumar', 'kumar@123', 'kumar@example.com'),
('ram', 'ram@123', 'ram@example.com'),
('ramesh', 'ramesh@123', 'ramesh@example.com'),
('suresh', 'suresh@123', 'suresh@example.com'),
('arun', 'arun@123', 'arun@example.com'),
('rajesh', 'rajesh@123', 'rajesh@example.com'),
('vignesh', 'vignesh@123', 'vignesh@example.com'),
('sathish', 'sathish@123', 'sathish@example.com'),
('mahesh', 'mahesh@123', 'mahesh@example.com'),
('deepak', 'deepak@123', 'deepak@example.com');

INSERT INTO ExpenseCategories (category_name) VALUES
('Groceries'),
('Utilities'),
('Rent'),
('Transportation'),
('Entertainment'),
('Dining Out'),
('Healthcare'),
('Education'),
('Savings'),
('Other');

INSERT INTO Expenses (user_id, amount, category_id, date, description) VALUES
(1, 1200.00, 1, '2025-04-01', 'Monthly grocery shopping at Nilgiris'),
(2, 800.00, 2, '2025-04-02', 'TNEB electricity bill'),
(3, 7500.00, 3, '2025-04-03', 'Flat rent'),
(4, 500.00, 4, '2025-04-04', 'Petrol expense'),
(5, 300.00, 5, '2025-04-05', 'Cinema at AGS'),
(6, 450.00, 6, '2025-04-06', 'Dinner at Saravana Bhavan'),
(7, 950.00, 7, '2025-04-07', 'Clinic consultation and medicines'),
(8, 2000.00, 8, '2025-04-08', 'Online Data Science course'),
(9, 5000.00, 9, '2025-04-09', 'Savings to SBI RD account'),
(10, 700.00, 10, '2025-04-10', 'Miscellaneous personal expenses');

select * from Users
select * from Expenses
select * from ExpenseCategories




