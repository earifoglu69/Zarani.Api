using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Zarani.Domain.Response;

namespace Zarani.Application.Services
{
    public interface ITokenService
    {
        Task<LoginResponse> CreateTokenByUser(ClaimsPrincipal loginResult);

    }
}
