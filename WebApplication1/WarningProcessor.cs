using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using Newtonsoft.Json;
using System;

namespace WebApplication1
{
    internal class WarningProcessor : ITelemetryProcessor
    {
        private readonly ITelemetryProcessor _next;

        public WarningProcessor(ITelemetryProcessor next)
        {
            _next = next;
        }
        public void Process(ITelemetry item)
        {
            if (!OkToSend(item))
                return;

            _next.Process(item);
        }

        private bool OkToSend(ITelemetry item)
        {
            if (item is Microsoft.ApplicationInsights.DataContracts.TraceTelemetry e && e.SeverityLevel != null)
            {
                try
                {
                    var obj = JsonConvert.DeserializeObject<Models.LogMessage>(e.Message);
                    if (obj != null)
                    {
                        e.Message = obj.Message;
                        e.Properties[string.IsNullOrWhiteSpace(obj.PropertyName) ? "Data" : obj.PropertyName] = JsonConvert.SerializeObject(obj.Data);
                    }
                }
                catch (JsonReaderException)
                {
                    return true;
                }
            }
            return true;
        }
    }
}