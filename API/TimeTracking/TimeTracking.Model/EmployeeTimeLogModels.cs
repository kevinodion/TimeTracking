using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTracking.Model
{
    public class EmployeeTimeLogModel
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime ClockInTime { get; set; }
        public DateTime? ClockOutTime { get; set; }
        public bool IsActive { get; set; }
    }

    public class EmployeeListModel
    {
        public List<EmployeeTimeLogModel> Employees { get; set; }
        public int CurrentPage { get; set; } = 0;
        public int TotalCount { get; set; } = 0;
    }
}
