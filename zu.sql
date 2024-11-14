use master;
go

drop database if exists zu;
go


create database zu;
go

use zu;
go


use zu;



create table prostorija(
sifra int not null primary key identity(1,1),
dimenzije varchar (30),
maksbroj int not null,
mjesto varchar (30) 
);

create table djelatnik(
sifra int not null primary key identity (1,1),
ime varchar (50) not null,
prezime varchar (50) not null,
iban varchar (50) 
);

create table datum(
sifra int not null primary key identity (1,1),
drodenja datetime not null,
ddolaska datetime not null,
dsmrti datetime not null
);

create table zivotinja(
sifra int not null primary key identity(1,1),
vrsta varchar (50) not null,
ime varchar (50) not null,
djelatnik int not null references djelatnik(sifra),
prostorija int not null references prostorija(sifra),
datum int not null references datum(sifra)
);