using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace TimeTracking.DataAccess
{
    public class TimeTrackingDbContext : DbContext
    {
        public TimeTrackingDbContext()
        {

        }

        public TimeTrackingDbContext(DbContextOptions<TimeTrackingDbContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeTimeLog> EmployeeTimeLogs { get; set; }
    }
}
