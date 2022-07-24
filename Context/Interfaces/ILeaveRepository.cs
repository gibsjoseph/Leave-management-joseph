using Leave_Mgt.Models.Leavez;
namespace Leave_Mgt.Context.Interfaces
{
    public interface ILeaveRepository : IDisposable
    {
        IEnumerable<Leave> GetLeaves();
        Leave GetLeaveByID(int leaveId);
        void InsertLeave(Leave leave);
        void DeleteLeave(int leaveId);
        void UpdateLeave(Leave leave);
        void Save();
    }
}
