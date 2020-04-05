using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Logging
{
    public static class LoggerExtensions
    {
        public static void LogWarning(this ILogger logger, string message, object data, string propertyName)
        {

        }
        public static void LogWarning(this ILogger logger, string message, object data)
        {
            var msg = new WebApplication1.Models.LogMessage()
            {
                Message = message,
                Data = data
            };

            logger.LogWarning(JsonConvert.SerializeObject(msg));
        }
    }
}
