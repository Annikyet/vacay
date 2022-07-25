-- Active: 1658781532697@@SG-Azula-6401-mysql-master.servers.mongodirector.com@3306@vacay
CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS flights(
  id INT NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId VARCHAR(255) NOT NULL COMMENT 'creator ID',
  type VARCHAR(255) NOT NULL COMMENT 'Type of vacation',
  destination VARCHAR(255) NOT NULL COMMENT 'Vacation destination',
  price INT NOT NULL COMMENT 'Price in cents',
  departingAirport VARCHAR(255) COMMENT 'ICAO Airport Code of Airport departed from',
  arrivingAirport VARCHAR(255) COMMENT 'ICAO airport code of the airport arriving at',
  flightNumber VARCHAR(255) COMMENT 'Airline flight number',
  aircraftModel VARCHAR(255) COMMENT 'Model of aircraft flown on',
  seatNumber VARCHAR(255) COMMENT 'Seat Number for your seat',
  seatClass VARCHAR(255) COMMENT 'Class of your ticket'
) default charset utf8;

CREATE TABLE IF NOT EXISTS roadtrips(
  id INT NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId VARCHAR(255) NOT NULL COMMENT 'creator ID',
  type VARCHAR(255) NOT NULL COMMENT 'Type of vacation',
  destination VARCHAR(255) NOT NULL COMMENT 'Vacation destination',
  price INT NOT NULL COMMENT 'Price in cents',
  milesPerGallon FLOAT COMMENT 'MPG of car',
  numberOfStops INT COMMENT 'Number of stops on this journey',
  miles FLOAT COMMENT 'Number of miles driven',
  highway VARCHAR(255) COMMENT 'Name of highway (yes, I guess only ONE highway lol',
  milesPerHour FLOAT COMMENT 'Average MPH driven'
) default charset utf8;

CREATE TABLE IF NOT EXISTS trains(
  id INT NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId VARCHAR(255) NOT NULL COMMENT 'creator ID',
  type VARCHAR(255) NOT NULL COMMENT 'Type of vacation',
  destination VARCHAR(255) NOT NULL COMMENT 'Vacation destination',
  price INT NOT NULL COMMENT 'Price in cents',
  miles FLOAT COMMENT 'Miles travelled',
  route VARCHAR(255) COMMENT 'Name of train route',
  seatNumber VARCHAR(255) COMMENT 'Seatnumber of ticket',
  seatClass VARCHAR(255) COMMENT 'Class of ticket'
) default charset utf8;

select * from flights;