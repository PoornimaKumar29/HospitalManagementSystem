using HospitalManagementSystem.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace HospitalManagementSystem.dao
{
    public interface IHospitalService
    {
        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);

        // Doctor methods
        void AddDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        bool IsDoctorAvailable(int doctorId, DateTime date);
        Patient GetPatientById(int patientId);
        
            Appointment GetAppointmentById(int appointmentId);
        List<Appointment> GetAllAppointments();
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(int appointmentId);
        bool ScheduleAppointment(Appointment appointment);
        List<Appointment> GetAppointmentsForDoctor(int doctorId);
    }
}
