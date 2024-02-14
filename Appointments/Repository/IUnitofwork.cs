namespace Appointments.Repository
{
    public interface IUnitofwork:IDisposable
    {
        IAppointmentRepos Appointment {  get; }
        Task<int> Save();
    }
}
