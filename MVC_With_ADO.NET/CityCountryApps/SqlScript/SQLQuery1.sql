
create table Country
(
id int identity primary key not null,
name varchar(50) not null
)

create table City
(
id int identity primary key not null,
name varchar(50) not null,
countryId int not null,
foreign key(countryId) references Country(id)
)

create procedure GetAllCountry
as
begin 
select id, name from Country
end

create procedure AddCountry
(
@Name varchar(50)
)
as
begin
insert into Country values (@Name)
end

create procedure UpdateCountry
(
@Id int,
@Name varchar(50)
)
as
begin
update Country set name=@Name where id=@Id
end

create procedure DeleteCountry
(
@Id int
)
as
begin
delete Country where id=@Id
end

create procedure GetAllCityDetails
as
begin 
select c.id,c.name, cn.name as countryName
from City as c
left join Country as cn on c.countryId=cn.id
end

create procedure GetCountryIdByCitys
(
@Id int
)
as
begin 
select cn.id
from City as c
left join Country as cn on c.countryId=cn.id
where c.id=@Id
end

create procedure AddCity
(
@Name varchar (50),
@CountryId int
)
as
begin 
insert into City values(@Name,@CountryId)
end

create procedure UpdateCity
(
@Id int,
@Name varchar (50),
@CountryId int
)
as
begin 
update City set name=@Name, countryId=@CountryId where id=@Id
end

create procedure DeleteCity
(
@Id int
)
as
begin 
delete City where id=@Id
end