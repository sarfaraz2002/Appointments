using Appointments.DataContext;
using Appointments.Dto.RequestDto;
using Appointments.Dto.ResponseDto;
using Appointments.Models;
using Appointments.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Appointments.Repository;

namespace Appointments.Services.AppointmentService
{
    public class AppointmentServices:IAppointmentService
    {
        private readonly DbDataContext _dbConnection;
        private readonly IUnitofwork _unitOfWork;
        private readonly TimeValidationUtility _timeValidationUtility;
        private readonly DtosUtility _dtosUtility;
        public AppointmentServices(IUnitofwork unitOfWork,TimeValidationUtility timeValidationUtility, DtosUtility dtosUtility, DbDataContext dbConnection)
        {
            _unitOfWork = unitOfWork;
            _timeValidationUtility = timeValidationUtility;
            _dtosUtility = dtosUtility;
            _dbConnection= dbConnection;
        }
        public async Task<IEnumerable<AppointmentModel>> GetAppointments()
        {
            try
            {
                var appointments = await _unitOfWork.Appointment.GetAll();
                return appointments;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting appointments");
            }
        }
        public async Task<AppointmentModel> GetAppointmentById(int id)
        {

            var appointment = await _unitOfWork.Appointment.GetById(id);
            if (appointment is null)
            {
                throw new Exception("not found");
            }
            return appointment;
        }
        public async Task AddAppoinment(AppointmentReqDto appointment)
        {
            if (!DateValidationUtility.IsDateValid(appointment.AppointmentDate))
                throw new Exception("Invalid Date!Appointment date must be in the future.");

            DateTime generatedAppointmentTime = _timeValidationUtility.GenerateRandomTimeWithinRange(9, 19);

            var random = new Random();
            var count = await _dbConnection.Doctor.CountAsync();
            var randomIndex = random.Next(count);
            var randomDoctor = await _dbConnection.Doctor
                .Skip(randomIndex)
                .FirstOrDefaultAsync();
            try
            {
                var newAppointment = _dtosUtility.MapToDto(appointment, randomDoctor, "pending", generatedAppointmentTime);

                _unitOfWork.Appointment.Add(newAppointment);
                await _unitOfWork.Save();

                var responseDto = _dtosUtility.MapToResDto(newAppointment, randomDoctor);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding appointment: {ex.Message}");
            }
        }
        public async Task UpdateAppointment(EditReqDto editAppointment)
        {
            if (!DateValidationUtility.IsDateValid(editAppointment.AppointmentDate))
                throw new Exception("Invalid Date!Appointment date must be in the future.");

            DateTime generatedAppointmentTime = _timeValidationUtility.GenerateRandomTimeWithinRange(9, 19);

            AppointmentModel a = await _unitOfWork.Appointment.GetById(editAppointment.Id);
            if (a == null)
            {
                throw new Exception("Appointment is not found");
            }
            await _dtosUtility.MapToUpdate(a,editAppointment, generatedAppointmentTime);

            await _unitOfWork.Save();

        }
        public async Task<string> DeleteAppointment(int id)
        {
            try
            {
                var appointment = await _unitOfWork.Appointment.GetById(id);
                if (appointment != null)
                {
                    _dbConnection.Addresses.Remove(appointment.Address);
                    _unitOfWork.Appointment.Remove(appointment);
                    await _unitOfWork.Save();

                    return "Appointment deleted successfully.";
                }
                else
                {
                    return "Appointment not found.";
                }
            }
            catch (Exception ex)
            {
                return $"Error deleting appointment: {ex.Message}";
            }
        }
        public async Task UpdateAppointmentSpecific(int id, DateTime? newAppointmentDate, string updatedStatus)
        {
            if (newAppointmentDate.HasValue && !DateValidationUtility.IsDateValid(newAppointmentDate.Value))
            {
                throw new Exception("Invalid Date! Appointment date must be in the future.");
            }

            var appointment = await _unitOfWork.Appointment.GetById(id);
            if (appointment == null)
            {
                throw new Exception($"Appointment with ID {id} not found.");
            }

            if (newAppointmentDate.HasValue)
            {
                DateTime generatedAppointmentTime = _timeValidationUtility.GenerateRandomTimeWithinRange(9, 19);
                appointment.AppointmentDate = newAppointmentDate.Value;
                appointment.AppointmentTime = generatedAppointmentTime.TimeOfDay;
                appointment.Status = "Rescheduled";
            }
            else if (!string.IsNullOrWhiteSpace(updatedStatus))
            {
                appointment.Status = updatedStatus;
            }
            else
            {
                throw new Exception("Invalid request. Please provide either appointment date or status to update.");
            }

            appointment.UpdatedAt = DateTime.Now;
            await _unitOfWork.Save();
        }

    }
}
