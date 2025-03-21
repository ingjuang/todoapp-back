using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TodoApp_Back.Application.Services.Interfaces;

namespace TodoApp_Back.Application.Services
{
    public class HmacService : IHmacService
    {
        private readonly string _secretKey;

        public HmacService(IOptions<HmacSettings> hmacSettings)
        {
            _secretKey = hmacSettings.Value.SecretKey;
        }
        public string GenerateHmac(string message)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_secretKey));
            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
            return Convert.ToBase64String(hash);
        }

        public bool ValidateHmac(string message, string receivedHmac)
        {
            string expectedHmac = GenerateHmac(message);
            return expectedHmac == receivedHmac;
        }
    }
}
