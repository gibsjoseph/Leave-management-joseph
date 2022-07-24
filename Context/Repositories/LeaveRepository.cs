using Leave_Mgt.Context.Interfaces;
using Leave_Mgt.Context;
using Leave_Mgt.Models.Leavez;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Leave_Mgt.Context.Repositories
{ 
    public class LeaveRepository : ILeaveRepository
    {
        private LeaveMgtContext _context;
        public LeaveRepository(LeaveMgtContext leaveMgtContext)
        {
            this._context = leaveMgtContext;
        }
        public IEnumerable<Leave> GetLeaves()
        {
            return _context.lLeaves .ToList();
        }
        public Leave GetLeaveByID(int id)
        {
            return _context.lLeaves.Find(id);
        }
        public void InsertLeave(Leave leave)
        {
            _context.lLeaves.Add(leave);
        }
        public void DeleteLeave(int leaveID)
        {
            Leave leave = _context.lLeaves.Find(leaveID);
            _context.lLeaves.Remove(leave);
        }
        public void UpdateLeave(Leave leave)
        {
            _context.Entry(leave).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

