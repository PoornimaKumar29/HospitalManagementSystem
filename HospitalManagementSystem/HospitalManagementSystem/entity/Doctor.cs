using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.entity
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string ContactNumber { get; set; }

        // Default Constructor
        public Doctor() { }

        // Parameterized Constructor
        public Doctor(int doctorId, string firstName, string lastName, string specialization, string contactNumber)
        {
            this.DoctorId = doctorId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Specialization = specialization;
            this.ContactNumber = contactNumber;
        }
    }
}
