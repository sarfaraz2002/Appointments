using Appointments.Models;

namespace Appointments.Dto.ResponseDto
{
    public class AppointmentResDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public AddressResDto Address { get; set; }
        public string DiseaseType { get; set; }
        public string Description { get; set; }

        public Doctor Doctor { get; set; }
        public String Status { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
    }
}
