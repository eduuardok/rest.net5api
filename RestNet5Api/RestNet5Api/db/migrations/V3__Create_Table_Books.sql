create table if not exists person (
id bigint(20) not null auto_increment,
address varchar(100),
first_name varchar(80),
last_name varchar(80),
gender varchar(10),
primary key (id)
);