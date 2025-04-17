using System;
using HospitalManagementSystem.dao;
using HospitalManagementSystem.entity;
using HospitalManagementSystem.exception.HospitalManagementSystem.myexceptions;

namespace HospitalManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            IHospitalServiceImpl hospitalService = new IHospitalServiceImpl();

            while (true)
            {
                Console.WriteLine("Hospital Management System");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Add Doctor");
                Console.WriteLine("3. Update Patient");
                Console.WriteLine("4. Update Doctor");
                Console.WriteLine("5. Schedule Appointment");
                Console.WriteLine("6. Get All Appointments");
                Console.WriteLine("7. Get Appointment by ID");
                Console.WriteLine("8. Update Appointment");
                Console.WriteLine("9. Delete Appointment");
                Console.WriteLine("10. Get Appointments for a Doctor");
                Console.WriteLine("11. Check Doctor Availability");
                Console.WriteLine("12. Get patient by Id");
                Console.WriteLine("13. Exit");
                Console.Write("Choose an option: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Add Patient
                        Console.WriteLine("Enter Patient Details:");
                        Console.Write("First Name: ");
                        string patientFirstName = Console.ReadLine();
                        Console.Write("Last Name: ");
                        string patientLastName = Console.ReadLine();
                        Console.Write("Date of Birth (yyyy-mm-dd): ");
                        DateTime patientDob = DateTime.Parse(Console.ReadLine());
                        Console.Write("Gender: ");
                        string patientGender = Console.ReadLine();
                        Console.Write("Contact Number: ");
                        string patientContact = Console.ReadLine();
                        Console.Write("Address: ");
                        string patientAddress = Console.ReadLine();

                        Patient patient = new Patient
                        {
                            FirstName = patientFirstName,
                            LastName = patientLastName,
                            DateOfBirth = patientDob,
                            Gender = patientGender,
                            ContactNumber = patientContact,
                            Address = patientAddress
                        };

                        hospitalService.AddPatient(patient);
                        Console.WriteLine("Patient added successfully.");
                        break;

                    case 2:
                        // Add Doctor
                        Console.WriteLine("Enter Doctor Details:");
                        Console.Write("First Name: ");
                        string doctorFirstName = Console.ReadLine();
                        Console.Write("Last Name: ");
                        string doctorLastName = Console.ReadLine();
                        Console.Write("Specialization: ");
                        string doctorSpecialization = Console.ReadLine();
                        Console.Write("Contact Number: ");
                        string doctorContact = Console.ReadLine();

                        Doctor doctor = new Doctor
                        {
                            FirstName = doctorFirstName,
                            LastName = doctorLastName,
                            Specialization = doctorSpecialization,
                            ContactNumber = doctorContact
                        };

                        hospitalService.AddDoctor(doctor);
                        Console.WriteLine("Doctor added successfully.");
                        break;

                    case 3:
                        // Update Patient
                        Console.WriteLine("Enter Patient ID to update:");
                        int patientId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Updated Patient Details:");
                        Console.Write("First Name: ");
                        string updatedPatientFirstName = Console.ReadLine();
                        Console.Write("Last Name: ");
                        string updatedPatientLastName = Console.ReadLine();
                        Console.Write("Date of Birth (yyyy-mm-dd): ");
                        DateTime updatedPatientDob = DateTime.Parse(Console.ReadLine());
                        Console.Write("Gender: ");
                        string updatedPatientGender = Console.ReadLine();
                        Console.Write("Contact Number: ");
                        string updatedPatientContact = Console.ReadLine();
                        Console.Write("Address: ");
                        string updatedPatientAddress = Console.ReadLine();

                        Patient updatedPatient = new Patient
                        {
                            PatientId = patientId,
                            FirstName = updatedPatientFirstName,
                            LastName = updatedPatientLastName,
                            DateOfBirth = updatedPatientDob,
                            Gender = updatedPatientGender,
                            ContactNumber = updatedPatientContact,
                            Address = updatedPatientAddress
                        };

                        hospitalService.UpdatePatient(updatedPatient);
                        Console.WriteLine("Patient updated successfully.");
                        break;

                    case 4:
                        // Update Doctor
                        Console.WriteLine("Enter Doctor ID to update:");
                        int doctorId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Updated Doctor Details:");
                        Console.Write("First Name: ");
                        string updatedDoctorFirstName = Console.ReadLine();
                        Console.Write("Last Name: ");
                        string updatedDoctorLastName = Console.ReadLine();
                        Console.Write("Specialization: ");
                        string updatedDoctorSpecialization = Console.ReadLine();
                        Console.Write("Contact Number: ");
                        string updatedDoctorContact = Console.ReadLine();

                        Doctor updatedDoctor = new Doctor
                        {
                            DoctorId = doctorId,
                            FirstName = updatedDoctorFirstName,
                            LastName = updatedDoctorLastName,
                            Specialization = updatedDoctorSpecialization,
                            ContactNumber = updatedDoctorContact
                        };

                        hospitalService.UpdateDoctor(updatedDoctor);
                        Console.WriteLine("Doctor updated successfully.");
                        break;

                    case 5:
                        // Schedule Appointment
                        Console.WriteLine("Enter Appointment Details:");
                        Console.Write("Patient ID: ");
                        int appointmentPatientId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Doctor ID: ");
                        int appointmentDoctorId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Appointment Date (yyyy-mm-dd): ");
                        DateTime appointmentDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Description: ");
                        string appointmentDescription = Console.ReadLine();

                        Appointment appointment = new Appointment
                        {
                            PatientId = appointmentPatientId,
                            DoctorId = appointmentDoctorId,
                            AppointmentDate = appointmentDate,
                            Description = appointmentDescription
                        };

                        bool isScheduled = hospitalService.ScheduleAppointment(appointment);
                        if (isScheduled)
                        {
                            Console.WriteLine("Appointment scheduled successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Appointment scheduling failed.");
                        }
                        break;

                    case 6:
                        // Get All Appointments
                        var allAppointments = hospitalService.GetAllAppointments();
                        Console.WriteLine("Appointments:");
                        foreach (var app in allAppointments)
                        {
                            Console.WriteLine($"ID: {app.AppointmentId}, Patient ID: {app.PatientId}, Doctor ID: {app.DoctorId}, Date: {app.AppointmentDate}, Description: {app.Description}");
                        }
                        break;

                    case 7:
                        // Get Appointment by ID
                        Console.Write("Enter Appointment ID: ");
                        int appointmentIdForSearch = Convert.ToInt32(Console.ReadLine());
                        Appointment appointmentById = hospitalService.GetAppointmentById(appointmentIdForSearch);
                        if (appointmentById != null)
                        {
                            Console.WriteLine($"ID: {appointmentById.AppointmentId}, Patient ID: {appointmentById.PatientId}, Doctor ID: {appointmentById.DoctorId}, Date: {appointmentById.AppointmentDate}, Description: {appointmentById.Description}");
                        }
                        else
                        {
                            Console.WriteLine("Appointment not found.");
                        }
                        break;

                    case 8:
                        // Update Appointment
                        Console.WriteLine("Enter Appointment ID to update:");
                        int appointmentIdToUpdate = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Updated Appointment Details:");
                        Console.Write("Patient ID: ");
                        int updatedPatientId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Doctor ID: ");
                        int updatedDoctorId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Appointment Date (yyyy-mm-dd): ");
                        DateTime updatedAppointmentDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Description: ");
                        string updatedAppointmentDescription = Console.ReadLine();

                        Appointment updatedAppointment = new Appointment
                        {
                            AppointmentId = appointmentIdToUpdate,
                            PatientId = updatedPatientId,
                            DoctorId = updatedDoctorId,
                            AppointmentDate = updatedAppointmentDate,
                            Description = updatedAppointmentDescription
                        };

                        hospitalService.UpdateAppointment(updatedAppointment);
                        Console.WriteLine("Appointment updated successfully.");
                        break;

                    case 9:
                        // Delete Appointment
                        Console.Write("Enter Appointment ID to delete: ");
                        int appointmentIdToDelete = Convert.ToInt32(Console.ReadLine());
                        hospitalService.DeleteAppointment(appointmentIdToDelete);
                        Console.WriteLine("Appointment deleted successfully.");
                        break;

                    case 10:
                        // Get Appointments for Doctor
                        Console.Write("Enter Doctor ID to get appointments: ");
                        int doctorIdForAppointments = Convert.ToInt32(Console.ReadLine());
                        var doctorAppointments = hospitalService.GetAppointmentsForDoctor(doctorIdForAppointments);
                        Console.WriteLine("Appointments for Doctor:");
                        foreach (var app in doctorAppointments)
                        {
                            Console.WriteLine($"ID: {app.AppointmentId}, Patient ID: {app.PatientId}, Date: {app.AppointmentDate}, Description: {app.Description}");
                        }
                        break;

                    case 11:
                        // Check Doctor Availability
                        Console.Write("Enter Doctor ID to check availability: ");
                        int doctorIdForAvailability = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Appointment Date (yyyy-mm-dd): ");
                        DateTime appointmentDateForAvailability = DateTime.Parse(Console.ReadLine());

                        bool isAvailable = hospitalService.IsDoctorAvailable(doctorIdForAvailability, appointmentDateForAvailability);
                        if (isAvailable)
                        {
                            Console.WriteLine("Doctor is available.");
                        }
                        else
                        {
                            Console.WriteLine("Doctor is not available.");
                        }
                        break;
                    case 12:
                        try
                        {
                            // Example: Get patient by ID
                            Console.WriteLine("Enter patient ID to search:");
                            int patientIdForSearch = Convert.ToInt32(Console.ReadLine());

                            Patient searchedPatient = hospitalService.GetPatientById(patientIdForSearch);  // Changed variable name here
                            Console.WriteLine($"Patient found: {searchedPatient.FirstName} {searchedPatient.LastName}");
                        }
                        catch (PatientNumberNotFoundException ex)
                        {
                            Console.WriteLine("Patient not found. " + ex.Message);
                        }
                        break;


                    case 13:
                        // Exit
                        Console.WriteLine("Exiting Hospital Management System...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
