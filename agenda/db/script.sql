create database schedules;
go

create table users_schedules (
	id int identity(1,1) not null primary key,
	StartDate datetime not null,
	EndDate datetime not null,
	Owner nvarchar(100) not null,
	Title nvarchar(100) not null,
	Description nvarchar(1000)
);
go

create index idxScheduleStart
on users_schedules (StartDate, Owner)
include (EndDate, Title);

create index idxScheduleEnd
on users_schedules (EndDate, Owner)
include (StartDate, Title);
go

commit;