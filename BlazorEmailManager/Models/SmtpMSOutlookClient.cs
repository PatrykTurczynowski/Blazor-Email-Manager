using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmailManager.Models
{
    public class SmtpMSOutlookClient : SmtpBaseEmailClient
    {
        public SmtpMSOutlookClient(string clientName, string hostName, int portNumber)
            : base(clientName, hostName, portNumber)
        {
        }

        private SecureSocketOptions secureSocketOptions;
        public SecureSocketOptions SecureSocketOptions
        {
            get => secureSocketOptions;

            set
            {
                secureSocketOptions = value;
            }
        }

        public override void SetSpecificParameter(string parameter)
        {
            if (Enum.TryParse(typeof(SecureSocketOptions), parameter, out object result))
            {
                secureSocketOptions = (SecureSocketOptions)result;
            }
        }

        public override string GetCurrentSettings()
        {
            return $"Current HostName:{this.HostName} - with port number: {this.PortNumber}, " +
                $"secureSocketOptions: {SecureSocketOptions}";
        }
    }
}
