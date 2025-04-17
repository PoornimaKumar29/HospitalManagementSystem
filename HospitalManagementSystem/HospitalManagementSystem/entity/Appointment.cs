using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.entity
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Description { get; set; }

        // Default Constructor
        public Appointment() { }

        // Parameterized Constructor
        public Appointment(int appointmentId, int patientId, int doctorId, DateTime appointmentDate, string description)
        {
            this.AppointmentId = appointmentId;
            this.PatientId = patientId;
            this.DoctorId = doctorId;
            this.AppointmentDate = appointmentDate;
            this.Description = description;
        }
    }
}
