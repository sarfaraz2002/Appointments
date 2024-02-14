namespace Appointments.Dto.RequestDto
{
    public class EditReqDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public AddressReqDto Address { get; set; }
        public string DiseaseType { get; set; }
        public string Description { get; set; }

        public DateTime AppointmentDate { get; set; }
    }
}
