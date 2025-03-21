using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp_Back.Application.Services.Interfaces
{
    public class HmacValidationRequest
    {
        public string Message { get; set; }
        public string ReceivedHmac { get; set; }
    }
}
