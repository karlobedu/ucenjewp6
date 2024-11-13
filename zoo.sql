use master;
go

drop database if exists zoo;
go

create database zoo;
go

use zoo;
go

create table djelatnik(
sifra int not null primary key identity (1,1),
ime varchar(50) not null,
prezime varchar(50) not null,
iban varchar(50),
);

create table datum(
d_rodenja datetime,
d_dolaska datetime,
d_smrti datetime,
sifra int not null primary key identity(1,1)
);

create table prostorija(
sifra int not null primary key identity(1,1),
dimenzije varchar(30) not null,
maks_broj int not null ,
mjesto varchar(30),
);

create table zivotinja(
sifra int not null primary key identity (1,1),
vrsta varchar(50)not null,
ime varchar(50)not null,
djelatnik int not null references djelatnik (sifra),
prostorija int not null references prostorija (sifra),
datum int not null references datum(sifra),
);
 