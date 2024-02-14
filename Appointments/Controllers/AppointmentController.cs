using Microsoft.AspNetCore.Mvc;
using Appointments.Services.AppointmentService;
using Appointments.Models;
using Appointments.Dto.RequestDto;
using Appointments.Dto.ResponseDto;
using Microsoft.AspNetCore.Authorization;
namespace Appointments.Controllers
{
    //[Authorize(Roles = "user")]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [Authorize(Roles = "user")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentModel>>> GetAppointmentAll()
        {
            try
            {
                var appointments = await _appointmentService.GetAppointments();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }
        [Authorize(Roles = "user")]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentModel>> GetById(int id)
        {
            try
            {
                var appointments = await _appointmentService.GetAppointmentById(id);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost()]
        public async Task<ActionResult> AddAppointment(AppointmentReqDto appointment)
        {
            try
            {
                await _appointmentService.AddAppoinment(appointment);
                return Ok("Appointment Created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateAppointment(EditReqDto editAppointment)
        {
            try
            {
                await _appointmentService.UpdateAppointment(editAppointment);
                return Ok("Appointment updated successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "user")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            try
            {
                var result = await _appointmentService.DeleteAppointment(id);

                if (result == "Appointment deleted successfully.")
                {
                    return Ok(result);
                }
                else if (result == "Appointment not found.")
                {
                    return NotFound(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [Authorize(Roles = "user")]
        [HttpGet("Search")]
        public async Task<IActionResult> Search(DateTime? date = null, string requestorName = null, string status = null)
        {
            IEnumerable<AppointmentModel> filteredAppointments = await _appointmentService.GetAppointments();

            if (date != null)
                filteredAppointments = filteredAppointments.Where(a => a.AppointmentDate.Date == date.Value.Date);

            if (!string.IsNullOrWhiteSpace(requestorName))
                filteredAppointments = filteredAppointments.Where(a => a.Name.ToLower().Contains(requestorName.ToLower()));

            if (!string.IsNullOrWhiteSpace(status))
                filteredAppointments = filteredAppointments.Where(a => a.Status.ToLower() == status.ToLower());

            return Ok(filteredAppointments);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, DateTime? date = null, string status = null)
        {
            try
            {
                if ((date == null && string.IsNullOrWhiteSpace(status)))
                {
                    return BadRequest("Invalid request. Please provide either appointment date or status to update.");
                }

                if (!string.IsNullOrWhiteSpace(status))
                {
                    await _appointmentService.UpdateAppointmentSpecific(id, date, status);
                    return Ok("Appointment status updated successfully");
                }
                else if (date.HasValue)
                {
                    await _appointmentService.UpdateAppointmentSpecific(id, date.Value, status);
                    return Ok("Appointment rescheduled successfully");
                }
                else
                {
                    return BadRequest("Invalid request. Please provide either appointment date or status to update.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }
        [Authorize(Roles = "user")]
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("Please provide a valid file.");
                }
                var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";

                var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

                if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }
                var filePath = Path.Combine(uploadDirectory, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return Ok(new { FilePath = filePath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
