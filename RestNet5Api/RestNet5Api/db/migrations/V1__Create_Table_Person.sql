create table if not exists books (
id bigint(20) not null auto_increment,
author varchar(255),
launch_date datetime,
price decimal(65,2),
title varchar(255),
primary key (id)
);