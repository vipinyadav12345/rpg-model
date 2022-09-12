using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.models
{
    public class ServiceResponse<T>
    {
        public T ? Data  { get; set; }
        public bool success { get; set; }

        public string  Message { get; set; } = string.Empty;
        
    }
}