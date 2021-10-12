using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimeTracking.Core.Abstraction;
using TimeTracking.DataAccess;
using TimeTracking.Model;

namespace TimeTracking.Core.Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private TimeTrackingDbContext _timeTrackingDbContext;
        public EmployeeRepository(TimeTrackingDbContext timeTrackingDbContext)
        {
            _timeTrackingDbContext = timeTrackingDbContext;
        }

        public async Task<EmployeeListModel> GetTimeLogAsync()
        {
            EmployeeListModel model = new EmployeeListModel();

            var result = await _timeTrackingDbContext.EmployeeTimeLogs
                                                    .Select(s => new EmployeeTimeLogModel
                                                    {
                                                        ID = s.ID,
                                                        EmployeeName = s.EmployeeName,
                                                        ClockInTime = s.ClockInTime,
                                                        ClockOutTime = (s.ClockOutTime.HasValue ? s.ClockOutTime.Value : new Nullable<DateTime>()),
                                                        IsActive = s.IsActive
                                                    })
                                                    .OrderByDescending(o => o.ClockInTime)
                                                    .ToListAsync();

            model.TotalCount = result.Count();
            model.Employees = result.Take(10).ToList();

            return model;
        }

        public async Task<EmployeeTimeLogModel> GetTimeLogByIdAsync(int id)
        {
            var result = await _timeTrackingDbContext.EmployeeTimeLogs
                                                        .Where(w => w.ID == id)
                                                        .Select(s => new EmployeeTimeLogModel
                                                        {
                                                            ID = s.ID,
                                                            EmployeeName = s.EmployeeName,
                                                            ClockInTime = s.ClockInTime,
                                                            ClockOutTime = (s.ClockOutTime.HasValue ? s.ClockOutTime.Value : new Nullable<DateTime>()),
                                                            IsActive = s.IsActive
                                                        }).SingleOrDefaultAsync();

            return result;
        }

        public async Task<EmployeeListModel> UpdateTimeLogAsync(EmployeeTimeLogModel model)
        {
            EmployeeTimeLog employeeTimeLog = await _timeTrackingDbContext.EmployeeTimeLogs.FirstOrDefaultAsync(f => f.ID == model.ID);

            employeeTimeLog.EmployeeName = model.EmployeeName;
            employeeTimeLog.ClockInTime = model.ClockInTime;
            employeeTimeLog.ClockOutTime = (model.ClockOutTime.HasValue ? model.ClockOutTime.Value : new Nullable<DateTime>());
            employeeTimeLog.IsActive = model.IsActive;

            _timeTrackingDbContext.Entry<EmployeeTimeLog>(employeeTimeLog).State = EntityState.Modified;
            await _timeTrackingDbContext.SaveChangesAsync();

            var result = await _timeTrackingDbContext.EmployeeTimeLogs
                                                    .Select(s => new EmployeeTimeLogModel
                                                    {
                                                        ID = s.ID,
                                                        EmployeeName = s.EmployeeName,
                                                        ClockInTime = s.ClockInTime,
                                                        ClockOutTime = (s.ClockOutTime.HasValue ? s.ClockOutTime.Value : new Nullable<DateTime>()),
                                                        IsActive = s.IsActive
                                                    })
                                                    .OrderByDescending(o => o.ClockInTime)
                                                    .ToListAsync();

            EmployeeListModel employeeListModel = new EmployeeListModel();

            employeeListModel.TotalCount = result.Count();
            employeeListModel.Employees = result.Take(10).ToList();

            return employeeListModel;
        }

        public async Task<EmployeeListModel> DeleteTimeLogAsync(int id)
        {
            EmployeeTimeLog employeeTimeLog = await _timeTrackingDbContext.EmployeeTimeLogs.FirstOrDefaultAsync(f => f.ID == id);

            _timeTrackingDbContext.Entry<EmployeeTimeLog>(employeeTimeLog).State = EntityState.Deleted;
            await _timeTrackingDbContext.SaveChangesAsync();

            var result = await _timeTrackingDbContext.EmployeeTimeLogs
                                                    .Select(s => new EmployeeTimeLogModel
                                                    {
                                                        ID = s.ID,
                                                        EmployeeName = s.EmployeeName,
                                                        ClockInTime = s.ClockInTime,
                                                        ClockOutTime = (s.ClockOutTime.HasValue ? s.ClockOutTime.Value : new Nullable<DateTime>()),
                                                        IsActive = s.IsActive
                                                    })
                                                    .OrderByDescending(o => o.ClockInTime)
                                                    .ToListAsync();

            EmployeeListModel employeeListModel = new EmployeeListModel();

            employeeListModel.TotalCount = result.Count();
            employeeListModel.Employees = result.Take(10).ToList();

            return employeeListModel;
        }
    }
}
