create database Trips
go
use trips
--טבלת סוגי טיולים
create table tripsTypes(
idType smallint identity(1,1) primary key ,
nameType varchar(15),
)
go
--משתמשים
create table users(
idUser smallint identity(1,1) primary key ,
userFirstName varchar(12),
userLastName varchar(12),
userPhone varchar(10),
userMail varchar(15),
userPassword varchar(10),
userFirstAid bit,
)
go
--טבלת טיולים

create table trips(
idTrips smallint identity(1,1) primary key ,
DestinationTrip varchar(12),
idType smallint references tripsTypes(idType),
DateTrip date,
leavingTime smallint,
durationTrip smallint,
placesAvailable smallint,
price smallint,
image text,
)
go
--טבלת הזמנת מקומות
use trips
create table booking(
idBooking smallint identity(1,1) primary key ,
idUser smallint references users(idUser),
dateBookink date,
timeBooking smallint,
idTrip smallint references trips(idTrips),
places smallint,
)
go