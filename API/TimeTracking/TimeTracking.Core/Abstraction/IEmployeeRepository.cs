using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using TimeTracking.Model;

namespace TimeTracking.Core.Abstraction
{
    public interface IEmployeeRepository
    {
        Task<EmployeeListModel> GetTimeLogAsync();
        Task<EmployeeTimeLogModel> GetTimeLogByIdAsync(int id);
        Task<EmployeeListModel> UpdateTimeLogAsync(EmployeeTimeLogModel model);
        Task<EmployeeListModel> DeleteTimeLogAsync(int id);
    }
}
