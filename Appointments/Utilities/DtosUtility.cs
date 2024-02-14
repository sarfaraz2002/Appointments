using Appointments.Dto.RequestDto;
using Appointments.Dto.ResponseDto;
using Appointments.Models;

namespace Appointments.Utilities
{
    public class DtosUtility
    {
        public AppointmentModel MapToDto(AppointmentReqDto appointment, Doctor doctor, string status, DateTime generatedAppointmentTime)
        {
            return new AppointmentModel
            {
                Name = appointment.Name,
                Phone = appointment.Phone,
                Age = appointment.Age,
                DateOfBirth = appointment.DateOfBirth,
                BloodGroup = appointment.BloodGroup,
                Address = new Address
                {
                    AddressId = Guid.NewGuid(),
                    ZipCode = appointment.Address.ZipCode,
                    City = appointment.Address.City,
                    State = appointment.Address.State,
                    District = appointment.Address.District
                },
                DiseaseType = appointment.DiseaseType,
                Description = appointment.Description,
                AppointmentDate = appointment.AppointmentDate,
                AppointmentTime = generatedAppointmentTime.TimeOfDay,
                Status = status,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Doctor = doctor
            };
        }
        public AppointmentResDto MapToResDto(AppointmentModel newAppointment, Doctor doctor)
         {
             return new AppointmentResDto
                {
                    Name = newAppointment.Name,
                    Phone = newAppointment.Phone,
                    Age = newAppointment.Age,
                    BloodGroup = newAppointment.BloodGroup,
                    DateOfBirth= newAppointment.DateOfBirth,
                    Address = new AddressResDto
                    {
                        ZipCode = newAppointment.Address.ZipCode,
                        City = newAppointment.Address.City,
                        State = newAppointment.Address.State,
                        District = newAppointment.Address.District
                    },
                    DiseaseType = newAppointment.DiseaseType,
                    Description = newAppointment.Description,
                    AppointmentDate = newAppointment.AppointmentDate,
                    AppointmentTime = newAppointment.AppointmentTime,
                    Status = newAppointment.Status,
                    Doctor = doctor
                };
           }
        public async Task MapToUpdate(AppointmentModel a, EditReqDto editAppointment, DateTime generatedAppointmentTime)
        {
            a.Age = editAppointment.Age;
            a.AppointmentDate = editAppointment.AppointmentDate;
            a.AppointmentTime = generatedAppointmentTime.TimeOfDay;
            a.Description = editAppointment.Description;
            a.BloodGroup = editAppointment.BloodGroup;
            a.DateOfBirth = editAppointment.DateOfBirth;
            a.Phone = editAppointment.Phone;
            a.DiseaseType = editAppointment.DiseaseType;
            a.Address.City = editAppointment.Address.City;
            a.Address.State = editAppointment.Address.State;
            a.Address.District = editAppointment.Address.District;
            a.Address.ZipCode = editAppointment.Address.ZipCode;
            a.Name = editAppointment.Name;
            a.UpdatedAt = DateTime.Now;
            a.Status = "Updated";
        }
    }
}