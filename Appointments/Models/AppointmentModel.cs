namespace Appointments.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }    
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public Address Address { get; set; }
        public string DiseaseType { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
