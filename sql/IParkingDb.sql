IF DB_ID('IParkingDb') IS NULL
BEGIN
   CREATE DATABASE IParkingDb;
END
ELSE
BEGIN
 PRINT('DATABASE ALREADY EXISTS');
END
GO

BEGIN TRY   
BEGIN TRANSACTION

USE [IParkingDb]

DROP TABLE IF EXISTS dbo.ParkingTime
DROP TABLE IF EXISTS dbo.Car
DROP TABLE IF EXISTS dbo.Customer
DROP TABLE IF EXISTS dbo.CustomerType


CREATE TABLE CustomerType
(
   CustomerTypeId  INT NOT NULL,
   TypeDescription VARCHAR(100) NOT NULL,
   CONSTRAINT PK_CustomerType PRIMARY KEY (CustomerTypeId)
);

CREATE TABLE Customer
(
   CustomerId  INT NOT NULL IDENTITY(1,1),
   FullName VARCHAR(200) NOT NULL,
   CustomerTypeId INT NOT NULL,
   CONSTRAINT PK_Customer PRIMARY KEY (CustomerId),
   CONSTRAINT FK_Customer_CustomerType FOREIGN KEY (CustomerTypeId) REFERENCES CustomerType(CustomerTypeId)
);

CREATE TABLE Car
(
   CarId  INT NOT NULL IDENTITY(1,1),
   Model VARCHAR(300) NULL,
   Plate VARCHAR(20) NOT NULL,
   CustomerId INT NOT NULL,
   CONSTRAINT PK_Car PRIMARY KEY (CarId),
   CONSTRAINT FK_Car_Customer FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId) 
);

CREATE TABLE ParkingTime
(
   ParkingTimeId INT NOT NULL IDENTITY(1,1),
   StartTime DATETIME NOT NULL,
   EndTime DATETIME NOT NULL,
   Total Decimal(10,2) NOT NULL,
   CarId INT NOT NULL,
   CONSTRAINT PK_ParkingTime PRIMARY KEY (ParkingTimeId),
   CONSTRAINT FK_ParkingTime_Car FOREIGN KEY (CarId) REFERENCES Car(CarId) 
);



INSERT INTO CustomerType
(CustomerTypeId, TypeDescription)
values
(1, 'Premium'),
(2, 'Regular')

INSERT INTO Customer
values
('Mario', 1)

INSERT INTO Car
values
('Golf', 'BRA-1234', 1);

SELECT * FROM CustomerType

SELECT * FROM Customer

SELECT * FROM Car

SELECT * FROM ParkingTime

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
    -- Execute the error retrieval routine.
        SELECT 
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_STATE() as ErrorState,
        ERROR_PROCEDURE() as ErrorProcedure,
        ERROR_LINE() as ErrorLine,
        ERROR_MESSAGE() as ErrorMessage;    
END CATCH