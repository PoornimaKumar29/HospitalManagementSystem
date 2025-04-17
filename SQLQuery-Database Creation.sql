create database HMS
use HMS

-- 1. Patient Table
CREATE TABLE Patient (
    patientId INT IDENTITY(1,1) PRIMARY KEY,
    firstName VARCHAR(50) NOT NULL,
    lastName VARCHAR(50) NOT NULL,
    dateOfBirth DATE NOT NULL,
    gender VARCHAR(10) NOT NULL,
    contactNumber VARCHAR(15) NOT NULL,
    address VARCHAR(100) NOT NULL
);

-- 2. Doctor Table
CREATE TABLE Doctor (
    doctorId INT IDENTITY(1,1) PRIMARY KEY,
    firstName VARCHAR(50) NOT NULL,
    lastName VARCHAR(50) NOT NULL,
    specialization VARCHAR(50) NOT NULL,
    contactNumber VARCHAR(15) NOT NULL
);

-- 3. Appointment Table
CREATE TABLE Appointment (
    appointmentId INT IDENTITY(1,1) PRIMARY KEY,
    patientId INT NOT NULL,
    doctorId INT NOT NULL,
    appointmentDate DATE NOT NULL,
    description VARCHAR(200),

    -- Foreign Keys
    CONSTRAINT fk_patient FOREIGN KEY (patientId) REFERENCES Patient(patientId) ON DELETE CASCADE,
    CONSTRAINT fk_doctor FOREIGN KEY (doctorId) REFERENCES Doctor(doctorId) ON DELETE CASCADE
);
