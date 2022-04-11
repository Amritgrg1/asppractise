create table product(
pid int primary key identity,
pname varchar(50),
pcategory varchar(50),
pmdate datetime not null);
create table orders(
oid int primary key identity,
pid int not null,
odate datetime,
oqty int,
foreign key(pid) references product(pid)

);

select * from sys.tables;