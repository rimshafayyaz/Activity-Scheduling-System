create table login(
username varchar(50) ,
email varchar(50)primary key,
password varchar(50)
)
insert into login(username,email,password)values('admin','admin@gmail.com','admin')
insert into login(username,email,password)values('rimsha','mishafayyaz@gmail.com','rimsha25')
insert into login(username,email,password)values('ayesha','ayeshakanwal@gmail.com','ayesha12')

select *from login