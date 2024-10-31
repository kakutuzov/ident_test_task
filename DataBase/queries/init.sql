CREATE EXTENSION pgcrypto; -- Необходим для генерации uuid
-- TASK 1
-- Variant 1

create table if not exists variant_one (
 user_id UUID PRIMARY KEY,
 first_name VARCHAR(20) NOT NULL,
 last_name VARCHAR(20) NOT NULL,
 middle_name VARCHAR(20) NOT NULL,
 phone_number bigint NOT NULL,
 medical_card_number bigint NOT NULL,
 tin integer NULL
);

-- Variant 2

create table if not exists variant_two_users (
 id UUID PRIMARY KEY,
 first_name VARCHAR(20) NOT NULL,
 last_name VARCHAR(20) NOT NULL,
 middle_name VARCHAR(20) NOT NULL,
 phone_number bigint NOT NULL
);

create table if not exists variant_two_employees(
 id UUID primary key,
 user_id UUID references variant_two_users(id),
 tin integer not null 
);

create table if not exists variant_two_patients(
 id UUID primary key,
 user_id UUID references variant_two_users(id),
 medical_card_number bigint not null
);

-- Variant 3

create table if not exists variant_three_user_main_info (
 id UUID PRIMARY KEY,
 first_name VARCHAR(20) NOT NULL,
 last_name VARCHAR(20) NOT NULL,
 middle_name VARCHAR(20) NOT NULL,
 phone_number bigint NOT NULL
);

create table if not exists variant_three_user_additional_info (
 id UUID PRIMARY KEY, 
 tin integer null,
 medical_card_number bigint null
);

create table if not exists variant_three_users (
 id UUID PRIMARY key,
 main_info_id UUID references variant_three_user_main_info(id),
 additional_info UUID references variant_three_user_additional_info(id)
);

-- TASK 2
-- initialize environment
create table if not exists patients(
 id serial primary key,
 name varchar(20) not null
);

create table if not exists docktors(
 id serial primary key,
 name varchar(20) not null
);

create table if not exists receptions(
 id serial primary key,
 id_patients bigint references patients(id),
 id_docktors bigint references docktors(id),
 start_date_time date not null
);

-- fill patients
insert into patients ("name")
values 
	('Дарья'),
	('Евгения'),
	('Мария'),
	('Александра'),
	('София'),
	('Анастасия'),
	('Галина'),
	('Яна'),
	('Вера'),
	('Екатерина')
	
-- fill docktors
insert into docktors ("name")
values
	('Александр'),
	('Михаил'),
	('Иван'),
	('Константин')
	

insert into receptions ("id_patients", "id_docktors", "start_date_time")
values
	(1, 3, '2015-01-04'),
	(5, 4, '2015-01-28'),
	(2, 1, '2015-02-13'),
	(1, 4, '2015-02-10'),
	(10, 4, '2015-02-20'),
	(6, 4, '2015-02-20'),
	(8, 4, '2015-02-20'),
	
	(1, 3, '2015-02-04'),
	(2, 2, '2015-02-08'),
	(3, 4, '2015-02-08'),
	(4, 1, '2015-02-08'),
	(5, 3, '2015-02-08'),
	(6, 3, '2015-02-10'),
	(9, 4, '2015-02-11'),
	
	(9, 1, '2015-02-16'),
	(8, 1, '2015-02-16'),
	(7, 1, '2015-02-16'),
	(6, 3, '2015-03-02'),
	(5, 3, '2015-03-02'),
	(4, 3, '2015-03-03'),
	(3, 2, '2015-03-03'),
	(2, 2, '2015-03-10'),
	(1, 4, '2015-03-10'),
	
	(9, 1, '2015-06-16'),
	(8, 1, '2015-07-16'),
	(7, 1, '2015-08-16'),
	(6, 3, '2015-08-02'),
	(5, 3, '2015-08-02'),
	(4, 3, '2015-06-03'),
	(3, 2, '2015-06-03'),
	(2, 2, '2015-09-10'),
	(1, 4, '2015-09-10'),
	
	(9, 1, '2015-04-01'),
	(8, 1, '2015-05-02'),
	(7, 1, '2015-06-03'),
	(6, 3, '2015-07-04'),
	(5, 3, '2015-08-05'),
	(4, 3, '2015-09-06'),
	(3, 2, '2015-10-07'),
	(2, 2, '2015-11-08'),
	(1, 4, '2015-12-09'),
	
	(9, 1, '2016-04-01'),
	(8, 1, '2016-05-02'),
	(7, 1, '2016-06-03'),
	(6, 3, '2016-07-04'),
	(5, 3, '2016-08-05'),
	(4, 3, '2016-09-06'),
	(3, 2, '2016-10-07'),
	(2, 2, '2016-11-08'),
	(1, 4, '2016-12-09')