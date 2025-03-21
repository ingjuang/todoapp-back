using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp_Back.Application.Services.Interfaces
{
    public interface IHmacService
    {
        public string GenerateHmac(string message);
        public bool ValidateHmac(string message, string receivedHmac);
    }
}
