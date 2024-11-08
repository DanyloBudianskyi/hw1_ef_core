use master
go

if db_id('ToDo') is not null
begin
	drop database ToDo
end
go
create database ToDo
go
use ToDo

create table Categories (
    Id int primary key identity(1,1),
    Name nvarchar(30) not null,
    Description nvarchar(50) not null
);


create table Tasks (
    Id int primary key identity(1,1),
    Name nvarchar(30) not null,
    Description nvarchar(50) not null,
    IsCompleted bit not null,
    CreateDate datetime not null,
    CategoryId int,
    foreign key (CategoryId) references Categories(Id) 
);

insert into Categories (Name, Description) values ('Work', 'Tasks related to work');
insert into Categories (Name, Description) values ('Personal', 'Personal errands and activities');
insert into Categories (Name, Description) values ('Hobby', 'Activities related to hobbies');

insert into Tasks (Name, Description, IsCompleted, CreateDate, CategoryId)
values ('Complete report', 'Finish the quarterly financial report', 0, '2024-11-01', 1);

insert into Tasks (Name, Description, IsCompleted, CreateDate, CategoryId)
values ('Grocery shopping', 'Buy groceries for the week', 0, '2024-11-02', 2);

insert into Tasks (Name, Description, IsCompleted, CreateDate, CategoryId)
values ('Practice guitar', 'Practice guitar for an hour', 1, '2024-11-03', 3);

insert into Tasks (Name, Description, IsCompleted, CreateDate, CategoryId)
values ('Team meeting', 'Attend the project meeting', 1, '2024-11-04', 1);

select * from Categories
select * from Tasks