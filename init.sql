if (not exists (select null from sys.databases where name = 'medicinedb'))
    create database medicinedb;
GO

use medicinedb;

if (not exists(select * from sys.tables where name = 'Section'))
    create table Section (
        SectionId int identity(1,1) primary key,
        SectionNumber int
    )
GO

if (not exists(select * from sys.tables where name = 'Specialization'))
    create table Specialization (
        SpecializationId int identity(1,1) primary key,
        SectionNumber nvarchar(100)
    )
GO

if (not exists(select * from sys.tables where name = 'Cabinet'))
    create table Cabinet (
        CabinetId int identity(1,1) primary key,
        CabinetNumber int
    )
GO

if (not exists(select * from sys.tables where name = 'Patient'))
    create table Patient (
        PatientId int identity(1,1) primary key,
        PatientLastName nvarchar(100),
        PatientFirstName nvarchar(100),
        PatientPatronymic nvarchar(100),
        PatientAddress ntext,
        PatientBirthday DATE,
        PatientGender nvarchar(1),
        SectionId int not null,
        constraint fk_Patient_Section foreign key (SectionId) references Section (SectionId)
    )
GO

if (not exists(select * from sys.tables where name = 'Medic'))
    create table Medic (
        MedicId int identity(1,1) primary key,
        MedicFullname nvarchar(300),
        CabinetId int not null,
        SpecializationId int not null,
        SectionId int not null,
        constraint fk_Medic_Cabinet foreign key (CabinetId) references Cabinet (CabinetId),
        constraint fk_Medic_Specialization foreign key (SpecializationId) references Specialization (SpecializationId),
        constraint fk_Medic_Section foreign key (SectionId) references Section (SectionId)

    )
GO