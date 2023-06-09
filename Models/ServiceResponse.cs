using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d_Videogame_Store.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; } = default!;
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}