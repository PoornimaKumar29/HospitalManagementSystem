-- 1. Insert data into Patient table
INSERT INTO Patient (firstName, lastName, dateOfBirth, gender, contactNumber, address)
VALUES 
('John', 'Doe', '1985-06-15', 'Male', '9876543210', '123 Elm St, Springfield'),
('Jane', 'Smith', '1990-03-22', 'Female', '9123456789', '456 Oak Rd, Greenfield'),
('Alice', 'Johnson', '1992-09-11', 'Female', '9345678901', '789 Pine Ave, Maplewood'),
('Bob', 'Brown', '1980-11-25', 'Male', '9456789012', '101 Birch Blvd, Hilltop'),
('Emily', 'Davis', '1987-01-30', 'Female', '9567890123', '202 Cedar Dr, Lakeview'),
('Michael', 'Wilson', '1995-05-04', 'Male', '9678901234', '303 Maple St, Rivertown'),
('Sophia', 'Taylor', '2000-12-05', 'Female', '9789012345', '404 Elmwood Ln, Brightville'),
('James', 'Miller', '1998-07-14', 'Male', '9890123456', '505 Oakwood Rd, Clearwater'),
('Olivia', 'Anderson', '1993-02-28', 'Female', '9001234567', '606 Pine Ln, Sunnyside'),
('Daniel', 'Thomas', '1994-08-17', 'Male', '9112345678', '707 Birch St, Oceanview');

-- 2. Insert data into Doctor table
INSERT INTO Doctor (firstName, lastName, specialization, contactNumber)
VALUES
('Dr. Sarah', 'Williams', 'Cardiology', '9801234567'),
('Dr. David', 'Jones', 'Neurology', '9812345678'),
('Dr. Laura', 'Brown', 'Pediatrics', '9823456789'),
('Dr. Mark', 'Taylor', 'Orthopedics', '9834567890'),
('Dr. Emily', 'Miller', 'Dermatology', '9845678901'),
('Dr. Daniel', 'Garcia', 'Psychiatry', '9856789012'),
('Dr. Sophia', 'Harris', 'Gynecology', '9867890123'),
('Dr. James', 'Martinez', 'General Surgery', '9878901234'),
('Dr. Robert', 'Thomas', 'Dentistry', '9889012345'),
('Dr. Olivia', 'Clark', 'Ophthalmology', '9890123456');

-- 3. Insert data into Appointment table
INSERT INTO Appointment (patientId, doctorId, appointmentDate, description)
VALUES
(1, 1, '2025-04-20', 'Routine cardiology check-up'),
(2, 2, '2025-04-21', 'Neurological examination for headaches'),
(3, 3, '2025-04-22', 'Pediatric consultation for vaccination'),
(4, 4, '2025-04-23', 'Orthopedic consultation for knee pain'),
(5, 5, '2025-04-24', 'Dermatology consultation for skin rash'),
(6, 6, '2025-04-25', 'Psychiatry session for anxiety issues'),
(7, 7, '2025-04-26', 'Gynecological check-up'),
(8, 8, '2025-04-27', 'General surgery consultation for hernia'),
(9, 9, '2025-04-28', 'Dental check-up and cleaning'),
(10, 10, '2025-04-29', 'Eye check-up for vision clarity');
