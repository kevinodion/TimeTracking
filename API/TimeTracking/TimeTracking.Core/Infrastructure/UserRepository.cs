using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using TimeTracking.Core.Abstraction;
using TimeTracking.DataAccess;
using TimeTracking.Model;

namespace TimeTracking.Core.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private List<UserModel> _userModels;
        private TimeTrackingDbContext _timeTrackingDbContext;

        public UserRepository(TimeTrackingDbContext timeTrackingDbContext)
        {
            this._userModels = new List<UserModel>()
            {
                new UserModel() { Username = "kevinodion", Password = "password", EmployeeName = "Kevin Odion" },
                new UserModel() { Username = "lorem", Password = "ipsum", EmployeeName = "Lorem Ipsum" },
                new UserModel() { Username = "testonly", Password = "test", EmployeeName = "Test Only" },
            };

            this._timeTrackingDbContext = timeTrackingDbContext; //new TimeTrackingDbContext();
        }

        public async Task<AuthenticateResponse> LoginAsync(AuthenticateRequest authenticateRequest)
        {
            AuthenticateResponse response = await Task.Run(() => this._userModels.Where(w => w.Username == authenticateRequest.Username
                                                                                            && w.Password == authenticateRequest.Password)
                                                                            .Select(s => new AuthenticateResponse() { EmployeeName = s.EmployeeName })
                                                                            .SingleOrDefault());

            if(response != null)
            {
                EmployeeTimeLog employeeTimeLog = new EmployeeTimeLog()
                {
                    EmployeeName = response.EmployeeName,
                    ClockInTime = DateTime.Now,
                    IsActive = true
                };

                await _timeTrackingDbContext.AddAsync(employeeTimeLog);
                await _timeTrackingDbContext.SaveChangesAsync();

                response.ID = employeeTimeLog.ID;
            }

            return response;
        }
    }
}
