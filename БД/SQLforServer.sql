USE master;
CREATE database LabTracker1;
use LabTracker1;



CREATE table WeekDay
(
	IDWeek nvarchar(100) primary key
)

insert into WeekDay (IDWeek)
    values ('Monday'),
	       ('Thuesday'),
		   ('Wednesday'),
		   ('Thursday'),
		   ('Friday'),
		   ('Saturday'),
		   ('Sunday')

CREATE table Semestr
(
	IDSem int CHECK 
    (IDSem>0 and IDSem<3) primary key,
	MonthDayStart nvarchar(5) not null,
	MonthDayEnd nvarchar(5) not null
)

CREATE table Cource
(
	IDCource int identity(1, 1) primary key,
	NumberCource int CHECK 
    (NumberCource>0 and NumberCource<5) not null
)



CREATE table Speciality
(
	NameSpeciality nvarchar(100) primary key
)
CREATE table SubGroup
(
	IDSubGroup int CHECK 
    (IDSubGroup>0 and IDSubGroup<3) primary key
)
CREATE table Groups
(
	IDGroup int identity(1, 1) primary key,
	NumberGroup int CHECK 
    (NumberGroup>0 and NumberGroup<11) not null,
	IDSpeciality nvarchar(100) constraint Group_Speciality_FK foreign key 
                            references Speciality(NameSpeciality),
	IDSubGroup int constraint Group_SubGroup_FK foreign key 
                            references SubGroup(IDSubGroup),
	IDCource int constraint Group_Cource_FK foreign key 
                            references Cource(IDCource)
)
CREATE table ListStudents
(
	IDStudent int primary key,
	Name nvarchar(50) not null,
	Surname nvarchar(50) not null,
	IDGroup int constraint StudentList_Group_FK foreign key 
                            references Groups(IDGroup)
)

CREATE table Student
(
	Login nvarchar(50) primary key,
	Password int not null,
	IDStudent int constraint Student_StudentList_FK foreign key 
                            references ListStudents(IDStudent),
	Email nvarchar(100),
	AboutMe nvarchar(250)
)



CREATE table ListLab
(
	IDLab int identity(1, 1) primary key,
	NameLab nvarchar(100) not null,
	Quantity int not null,
	IDCource int constraint ListLab_Cource_FK foreign key 
                            references Cource(IDCource),
	IDSpeciality nvarchar(100) constraint ListLab_Speciality_FK foreign key 
                            references Speciality(NameSpeciality),
	IDSem int constraint ListLab_Semestr_FK foreign key
				         references Semestr(IDSem)
)



CREATE table PlansPass
(
	IDPlan int identity(1, 1) primary key,
	IDGroup int constraint PlansPass_Group_FK foreign key 
                            references Groups(IDGroup),
	IDLab int constraint PlansPass_ListLab_FK foreign key 
                            references ListLab(IDLab),
	Date nvarchar(10) not null,
	Quantity int not null
)



CREATE table ListTeachers
(
	IDTeacher int primary key,
	Name nvarchar(50) not null,
	Surname nvarchar(50) not null
)

CREATE table Teacher
(
	Login nvarchar(50) primary key,
	Password int not null,
	IDTeacher int constraint Teacher_ListTeachers_FK foreign key 
                            references ListTeachers(IDTeacher),
	Email nvarchar(100),
	AboutMe nvarchar(250)
)



CREATE table ListLabTeacher
(
	IDListLabTeacher int identity(1, 1) primary key,
	IDTeacher int constraint ListLabTeacher_ListTeachers_FK foreign key 
                            references ListTeachers(IDTeacher),
	IDGroup int constraint ListLabTeacher_Group_FK foreign key 
                            references Groups(IDGroup),
	IDLab int constraint ListLabTeacher_ListLab_FK foreign key 
                            references ListLab(IDLab),
	WeekName nvarchar(100) constraint ListLabTeacher_WeekDay_FK foreign key 
                            references WeekDay(IDWeek)
)

DROP table StudentPass
CREATE table StudentPass
(
	IDStudentPass int identity(1, 1) primary key,
	IDStudent int constraint StudentPass_StudentList_FK foreign key 
                            references ListStudents(IDStudent),
	IDTeacher int constraint StudentPass_ListTeachers_FK foreign key 
                            references ListTeachers(IDTeacher),
	IDLab int constraint StudentPass_ListLab_FK foreign key 
                            references ListLab(IDLab),
	PassedQuantity int
)

CREATE table Admin
(
    Login nvarchar(25) primary key,
	Password int not null
)

insert into Admin (Login, Password)
    values ('YakubenkoKsenia2001FIT71', 1234567)

insert into Semestr(IDSem, MonthDayStart,MonthDayEnd)
	values(1,'01.09', '31.12'),
		  (2,'01.02', '06.06')

insert into Speciality(NameSpeciality)
	values('ISSMS')

insert into Speciality(NameSpeciality)
	values('ITS')

insert into Speciality(NameSpeciality)
	values('IST')

insert into Speciality(NameSpeciality)
	values('DEWP')		

insert into SubGroup(IDSubGroup)
	values(1),
		  (2)


insert into Cource(NumberCource)
	values(1),
		  (2),
		  (3),
		  (4)

insert into Groups(NumberGroup, IDSpeciality, IDSubGroup, IDCource)
	values(1, 'IST', 1, 1),
	      (1, 'IST', 1, 2),
		  (1, 'IST', 1, 3),
		  (1, 'IST', 1, 4),		  
		  (1, 'IST', 2, 1),
	      (1, 'IST', 2, 2),
		  (1, 'IST', 2, 3),
		  (1, 'IST', 2, 4),

		  (2, 'IST', 1, 1),
	      (2, 'IST', 1, 2),
		  (2, 'IST', 1, 3),
		  (2, 'IST', 1, 4),
		  (2, 'IST', 2, 1),
	      (2, 'IST', 2, 2),
		  (2, 'IST', 2, 3),
		  (2, 'IST', 2, 4),

		  (3, 'IST', 1, 1),
	      (3, 'IST', 1, 2),
		  (3, 'IST', 1, 3),
		  (3, 'IST', 1, 4),
		  (3, 'IST', 2, 1),
	      (3, 'IST', 2, 2),
		  (3, 'IST', 2, 3),
		  (3, 'IST', 2, 4),

		  (4, 'ITS', 1, 1),
	      (4, 'ITS', 1, 2),
		  (4, 'ITS', 1, 3),
		  (4, 'ITS', 1, 4),
		  (4, 'ITS', 2, 1),
	      (4, 'ITS', 2, 2),
		  (4, 'ITS', 2, 3),
		  (4, 'ITS', 2, 4),

		  (5, 'ITS', 1, 1),
	      (5, 'ITS', 1, 2),
		  (5, 'ITS', 1, 3),
		  (5, 'ITS', 1, 4),
		  (5, 'ITS', 2, 1),
	      (5, 'ITS', 2, 2),
		  (5, 'ITS', 2, 3),
		  (5, 'ITS', 2, 4),

		  (6, 'ITS', 1, 1),
	      (6, 'ITS', 1, 2),
		  (6, 'ITS', 1, 3),
		  (6, 'ITS', 1, 4),
		  (6, 'ITS', 2, 1),
	      (6, 'ITS', 2, 2),
		  (6, 'ITS', 2, 3),
		  (6, 'ITS', 2, 4),

		  (7, 'ISSMS', 1, 1),
	      (7, 'ISSMS', 1, 2),
		  (7, 'ISSMS', 1, 3),
		  (7, 'ISSMS', 1, 4),
		  (7, 'ISSMS', 2, 1),
	      (7, 'ISSMS', 2, 2),
		  (7, 'ISSMS', 2, 3),
		  (7, 'ISSMS', 2, 4),

		  (8, 'ISSMS', 1, 1),
	      (8, 'ISSMS', 1, 2),
		  (8, 'ISSMS', 1, 3),
		  (8, 'ISSMS', 1, 4),
		  (8, 'ISSMS', 2, 1),
	      (8, 'ISSMS', 2, 2),
		  (8, 'ISSMS', 2, 3),
		  (8, 'ISSMS', 2, 4),

		  (9, 'DEWP', 1, 1),
	      (9, 'DEWP', 1, 2),
		  (9, 'DEWP', 1, 3),
		  (9, 'DEWP', 1, 4),
		  (9, 'DEWP', 2, 1),
	      (9, 'DEWP', 2, 2),
		  (9, 'DEWP', 2, 3),
		  (9, 'DEWP', 2, 4),

		  (10, 'DEWP', 1, 1),
	      (10, 'DEWP', 1, 2),
		  (10, 'DEWP', 1, 3),
		  (10, 'DEWP', 1, 4),
		  (10, 'DEWP', 2, 1),
	      (10, 'DEWP', 2, 2),
		  (10, 'DEWP', 2, 3),
		  (10, 'DEWP', 2, 4)



insert into ListStudents (IDStudent, Name, Surname, IDGroup)
	values (10000, 'Ksenia', 'Yakubenko', 63)

insert into ListStudents (IDStudent, Name, Surname, IDGroup)
	values (10001, 'Anastasia', 'Lisunkova', 63)

insert into ListStudents (IDStudent, Name, Surname, IDGroup)
	values (10002, 'Michail', 'Dubrovski', 63)

insert into ListStudents (IDStudent, Name, Surname, IDGroup)
	values (10003, 'Marck', 'Antonchikov', 63)

insert into ListStudents (IDStudent, Name, Surname, IDGroup)
	values (10004, 'Ekaterina', 'Kerez', 27)

insert into ListStudents (IDStudent, Name, Surname, IDGroup)
	values (10005, 'Anna', 'Kostukova', 27)