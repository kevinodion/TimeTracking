using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using TimeTracking.Model;

namespace TimeTracking.Core.Abstraction
{
    public interface IUserRepository
    {
        Task<AuthenticateResponse> LoginAsync(AuthenticateRequest authenticateRequest);
    }
}
