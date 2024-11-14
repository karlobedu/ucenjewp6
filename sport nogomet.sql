use master;
go

drop database if exists sport;
go


create database sport;
go

use sport;
go


use sport;



create table trener(
sifra int not null primary key identity(1,1),
ime varchar (50) not null,
prezime varchar (50) not null,
klub int not null,
nacionalnost varchar (50) not null,
iskustvo int not null
);

create table igrac(
sifra int not null primary key identity (1,1),
ime varchar (50) not null,
prezime varchar (50) not null,
datum_rodenja datetime,
pozicija int not null,
broj_dresa varchar (50) not null,
klub int not null
);

create table utakmica(
sifra int not null primary key identity (1,1),
datum datetime not null,
vrijeme datetime not null,
lokacija varchar (50) not null,
stadion int not null,
domaci_klub int not null,
gostujuci_klub int not null
);

create table klub(
sifra int not null primary key identity(1,1),
naziv int not null,
osnovan datetime not null,
stadion varchar (50) not null,
predsjednik int not null,
drzava varchar (50) not null,
liga varchar (50) not null
);