--use edunovawp6;

use master;
go

drop database if exists zoo;
go

create database zoo;
go

use zoo;
go

--create database zoo;

--use zoo;

--create table zivotinja(
--sifra int,
--vrsta varchar(50),
--ime varchar(50),
--djelatnik int,
--prostorija int,
--datum int
--);

--drop table zivotinja;

create table djelatnik(
sifra int not null primary key identity(1,1),
ime varchar(50) not null,
prezime varchar(50) not null,
iban varchar(50)
);

create table datum(
sifra int not null primary key identity(1,1),
datumrodenja datetime,
datumdolaska datetime
);

create table prostorija(
sifra int not null primary key identity(1,1),
dimenzije varchar(30) not null,
maks_broj int not null,
mjesto varchar(30)
);

create table zivotinja(
sifra int not null primary key identity(1,1),
vrsta varchar(50) not null,
ime varchar(50) not null,
djelatnik int not null references djelatnik(sifra),
prostorija int not null references prostorija(sifra),
datum int not null references datum(sifra)
);