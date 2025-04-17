using HospitalManagementSystem.entity;
using HospitalManagementSystem.exception.HospitalManagementSystem.myexceptions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.dao
{
    public class IHospitalServiceImpl: IHospitalService
    {
        private readonly string connectionString = "Data Source=POORNIMA\\SQLSERVER2022;Initial Catalog=HMS;Integrated Security=True;";
        // Add patient
        public void AddPatient(Patient patient)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Patient (firstName, lastName, dateOfBirth, gender, contactNumber, address) " +
                               "VALUES (@firstName, @lastName, @dateOfBirth, @gender, @contactNumber, @address)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@firstName", patient.FirstName);
                command.Parameters.AddWithValue("@lastName", patient.LastName);
                command.Parameters.AddWithValue("@dateOfBirth", patient.DateOfBirth);
                command.Parameters.AddWithValue("@gender", patient.Gender);
                command.Parameters.AddWithValue("@contactNumber", patient.ContactNumber);
                command.Parameters.AddWithValue("@address", patient.Address);
                command.ExecuteNonQuery();
            }
        }
        // Add doctor
        public void AddDoctor(Doctor doctor)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Doctor (firstName, lastName, specialization, contactNumber) " +
                               "VALUES (@firstName, @lastName, @specialization, @contactNumber)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@firstName", doctor.FirstName);
                command.Parameters.AddWithValue("@lastName", doctor.LastName);
                command.Parameters.AddWithValue("@specialization", doctor.Specialization);
                command.Parameters.AddWithValue("@contactNumber", doctor.ContactNumber);
                command.ExecuteNonQuery();
            }
        }
        // Update patient
        public void UpdatePatient(Patient patient)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Patient SET firstName = @firstName, lastName = @lastName, dateOfBirth = @dateOfBirth, " +
                               "gender = @gender, contactNumber = @contactNumber, address = @address WHERE patientId = @patientId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@patientId", patient.PatientId);
                command.Parameters.AddWithValue("@firstName", patient.FirstName);
                command.Parameters.AddWithValue("@lastName", patient.LastName);
                command.Parameters.AddWithValue("@dateOfBirth", patient.DateOfBirth);
                command.Parameters.AddWithValue("@gender", patient.Gender);
                command.Parameters.AddWithValue("@contactNumber", patient.ContactNumber);
                command.Parameters.AddWithValue("@address", patient.Address);
                command.ExecuteNonQuery();
            }
        }

        // Update doctor
        public void UpdateDoctor(Doctor doctor)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Doctor SET firstName = @firstName, lastName = @lastName, specialization = @specialization, " +
                               "contactNumber = @contactNumber WHERE doctorId = @doctorId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@doctorId", doctor.DoctorId);
                command.Parameters.AddWithValue("@firstName", doctor.FirstName);
                command.Parameters.AddWithValue("@lastName", doctor.LastName);
                command.Parameters.AddWithValue("@specialization", doctor.Specialization);
                command.Parameters.AddWithValue("@contactNumber", doctor.ContactNumber);
                command.ExecuteNonQuery();
            }
        }
        //Get patient by id
        public bool ScheduleAppointment(Appointment appointment)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Appointment (patientId, doctorId, appointmentDate, description) VALUES (@patientId, @doctorId, @appointmentDate, @description)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@patientId", appointment.PatientId);
                    command.Parameters.AddWithValue("@doctorId", appointment.DoctorId);
                    command.Parameters.AddWithValue("@appointmentDate", appointment.AppointmentDate);
                    command.Parameters.AddWithValue("@description", appointment.Description);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true; // Appointment successfully scheduled
                    }
                    return false; // Appointment scheduling failed
                }
            }
            catch (Exception)
            {
                return false; // Appointment scheduling failed due to error
            }
        }

        public Patient GetPatientById(int patientId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Patient WHERE patientId = @patientId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@patientId", patientId);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Patient(
                        Convert.ToInt32(reader["patientId"]),
                        reader["firstName"].ToString(),
                        reader["lastName"].ToString(),
                        Convert.ToDateTime(reader["dateOfBirth"]),
                        reader["gender"].ToString(),
                        reader["contactNumber"].ToString(),
                        reader["address"].ToString()
                    );
                }
                else
                {
                    throw new PatientNumberNotFoundException("The patient number " + patientId + " does not exist.");
                }
            }
        }
        // Get appointment by ID
        public Appointment GetAppointmentById(int appointmentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Appointment WHERE appointmentId = @appointmentId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@appointmentId", appointmentId);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Appointment(
                        Convert.ToInt32(reader["appointmentId"]),
                        Convert.ToInt32(reader["patientId"]),
                        Convert.ToInt32(reader["doctorId"]),
                        Convert.ToDateTime(reader["appointmentDate"]),
                        reader["description"].ToString()
                    );
                }
                return null;
            }
        }
        // Get all appointments
        public List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Appointment";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    appointments.Add(new Appointment(
                        Convert.ToInt32(reader["appointmentId"]),
                        Convert.ToInt32(reader["patientId"]),
                        Convert.ToInt32(reader["doctorId"]),
                        Convert.ToDateTime(reader["appointmentDate"]),
                        reader["description"].ToString()
                    ));
                }
            }
            return appointments;
        }
        // Update appointment
        public void UpdateAppointment(Appointment appointment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Appointment SET patientId = @patientId, doctorId = @doctorId, appointmentDate = @appointmentDate, description = @description WHERE appointmentId = @appointmentId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@appointmentId", appointment.AppointmentId);
                command.Parameters.AddWithValue("@patientId", appointment.PatientId);
                command.Parameters.AddWithValue("@doctorId", appointment.DoctorId);
                command.Parameters.AddWithValue("@appointmentDate", appointment.AppointmentDate);
                command.Parameters.AddWithValue("@description", appointment.Description);
                command.ExecuteNonQuery();
            }
        }
        // Delete appointment by ID
        public void DeleteAppointment(int appointmentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Appointment WHERE appointmentId = @appointmentId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@appointmentId", appointmentId);
                command.ExecuteNonQuery();
            }
        }
        // Schedule an appointment (returns true if successfully scheduled)
        // Get all appointments for a specific doctor
        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            List<Appointment> appointments = new List<Appointment>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Appointment WHERE doctorId = @doctorId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@doctorId", doctorId);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    appointments.Add(new Appointment(
                        Convert.ToInt32(reader["appointmentId"]),
                        Convert.ToInt32(reader["patientId"]),
                        Convert.ToInt32(reader["doctorId"]),
                        Convert.ToDateTime(reader["appointmentDate"]),
                        reader["description"].ToString()
                    ));
                }
            }
            return appointments;
        }
        public bool IsDoctorAvailable(int doctorId, DateTime appointmentDateTime)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Appointment WHERE doctorId = @doctorId AND appointmentDate = @appointmentDate";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@doctorId", doctorId);
                command.Parameters.AddWithValue("@appointmentDate", appointmentDateTime);

                int count = (int)command.ExecuteScalar();

                // If count is 0, doctor is available at that time
                return count == 0;
            }
        }


    }
}
