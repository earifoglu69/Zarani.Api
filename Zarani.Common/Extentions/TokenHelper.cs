using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Zarani.Common.Extentions
{
    public static class TokenHelper
    {
        /// <summary>
        /// Create refresh token
        /// </summary>
        /// <returns>type of base 64 string</returns>
        public static string CreateRefreshToken()
        {
            var numberByte = new byte[32];
            using var random = RandomNumberGenerator.Create();
            random.GetBytes(numberByte);

            return Convert.ToBase64String(numberByte);
        }
    }
}
