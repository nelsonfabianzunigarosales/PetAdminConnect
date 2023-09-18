using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdminConnect.Shared.Responses
{
    public class Response<T>
    {
        public bool WasSuccess { get; set; }

        public string? Message { get; set; }

        public T? Result { get; set; }
    }
}
