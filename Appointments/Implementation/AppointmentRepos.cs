using Appointments.DataContext;
using Appointments.Models;
using Appointments.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;

namespace Appointments.Implementation
{
    public class AppointmentRepos : GenericRepos<AppointmentModel>, IAppointmentRepos
    {
        private readonly DbDataContext _dbConnection;
        public AppointmentRepos(DbDataContext dbConnection) : base(dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public new async Task<IEnumerable<AppointmentModel>> GetAll()
        {
            return await _dbConnection.Appointment.Include(a => a.Address).Include(a => a.Doctor).ToListAsync();
        }
        public new async Task<AppointmentModel> GetById(int id)
        {
            return await _dbConnection.Appointment.Include(p => p.Address).Include(p => p.Doctor).FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
