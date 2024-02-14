using Appointments.Dto.RequestDto;
using Appointments.Dto.ResponseDto;
using Appointments.Models;
using Microsoft.AspNetCore.Mvc;
namespace Appointments.Services.AppointmentService
{
    public interface IAppointmentService
    {
        public Task<IEnumerable<AppointmentModel>> GetAppointments();
        public Task<AppointmentModel> GetAppointmentById(int id);
        public Task AddAppoinment(AppointmentReqDto appointment);
        public Task UpdateAppointment(EditReqDto editAppointment);
        public Task<string> DeleteAppointment(int id);

        /*public Task RescheduleAppointment(int appointmentId, DateTime newAppointmentDate);
        public Task UpdateAppointmentStatus(int id, string updateStatus);*/
        public Task UpdateAppointmentSpecific(int id, DateTime? newAppointmentDate, string updatedStatus);
    }
}
