using Appointments.DataContext;
using Appointments.Repository;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Implementation
{
    public class UnitofWork : IUnitofwork
    {
        private readonly DbDataContext _dbConnection;
        public UnitofWork(DbDataContext dbConnection)
        {
            _dbConnection = dbConnection;
            Appointment = new AppointmentRepos(_dbConnection);
        }

        public IAppointmentRepos Appointment { get; set; }

        public void Dispose()
        {
            _dbConnection.Dispose();
        }

        public async Task<int> Save()
        {
            return await _dbConnection.SaveChangesAsync();
        }
    }
}
