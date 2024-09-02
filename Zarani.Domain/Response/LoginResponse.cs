using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zarani.Domain.Response
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
        public int ExpiresIn { get; set; }

        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
        public int RoleGroupId { get; set; }
        public string RoleGroupName { get; set; }
        public int MemberID { get; set; }
    }
}
