use master;
go

drop database if exists knjiznica;
go


create database knjiznica;
go

use knjiznica;
go


use knjiznica;



create table osobe(
sifra INT(11) not null,
ime VARCHAR(50) not null,
prezime VARCHAR(50) not null,
adresa VARCHAR(50) not null,
email VARCHAR(50) not null
);

create table vlasnik(
sifra INT(11) not null,
knjiga INT(11) not null
);

create table clan(
sifra INT(11) not null,
clbroj INT(11) not null
);

create table knjige(
sifra INT(11) not null,
naslov VARCHAR(50) not null,
pisac VARCHAR(50) not null,
vlasnik INT(11) not null,
clan INT(11) not null,
datumpos DATETIME not null,
datumvrac DATETIME not null
);