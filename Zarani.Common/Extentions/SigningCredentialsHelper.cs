using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zarani.Common.Extentions
{
    public static class SigningCredentialsHelper
    {
        /// <summary>
        /// Create signing credentials
        /// </summary>
        /// <param name="securityKey">security key object</param>
        /// <returns>type of signing credentials</returns>
        /// <exception cref="ArgumentNullException">when the security key is null</exception>
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            ArgumentNullException.ThrowIfNull(securityKey);
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
