using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmailManager.Models
{
    public abstract class SmtpBaseEmailClient
    {
        public SmtpBaseEmailClient(string clientName, string hostName, int portNumber)
        {
            this.ClientName = clientName;
            this.HostName = hostName;
            this.PortNumber = portNumber;
        }

        public string ClientName { get; set; }
        public string HostName { get; set; }
        public int PortNumber { get; set; }

        public abstract void SetSpecificParameter(string parameter);

        public virtual string GetCurrentSettings()
        {
            return $"Current HostName:{this.HostName} - with port number: {this.PortNumber}";
        }
    }
}
