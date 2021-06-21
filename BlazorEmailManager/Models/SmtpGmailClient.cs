using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmailManager.Models
{
    public class SmtpGmailClient : SmtpBaseEmailClient
    {
        public SmtpGmailClient(string clientName, string hostName, int portNumber)
            : base(clientName, hostName, portNumber)
        {
        }

        private int clientNumber;
        public int ClientNumber
        {
            get => clientNumber;

            set
            {
                clientNumber = value;
            }
        }

        public override void SetSpecificParameter(string parameter)
        {
            if (int.TryParse(parameter, out int result))
            {
                clientNumber = result;
            }
        }

        public override string GetCurrentSettings()
        {
            if (ClientNumber != 0)
            {
                return base.GetCurrentSettings();
            }
            else
            {
                return $"Client no: {ClientNumber} has current HostName:{this.HostName} - with port number: {this.PortNumber}";
            }
        }
    }
}
