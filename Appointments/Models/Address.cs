namespace Appointments.Models
{
    public class Address
    {
        public Guid AddressId { get; set; } =Guid.NewGuid();
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

    }
}
