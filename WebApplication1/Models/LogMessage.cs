using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class LogMessage
    {
        public string Message { get; set; }
        public string[] Objects { get; set; }
        public string PropertyName { get; set; }
        public object Data { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static implicit operator string(LogMessage msg) => msg.ToString();
    }
}
