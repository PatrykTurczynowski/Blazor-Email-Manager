using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmailManager.Models
{
    public class SmtpYahooClient : SmtpBaseEmailClient
    {
        public SmtpYahooClient(string clientName, string hostName, int portNumber)
            : base(clientName, hostName, portNumber)
        {
        }

        private string selectedSportTopic;
        public string SelectedSportTopic
        {
            get => selectedSportTopic;

            set
            {
                selectedSportTopic = value;
            }
        }

        public override void SetSpecificParameter(string parameter)
        {
            if (!string.IsNullOrEmpty(parameter))
            {
                selectedSportTopic = parameter;
            }
        }

        public override string GetCurrentSettings()
        {
            if (string.IsNullOrEmpty(SelectedSportTopic))
            {
                return base.GetCurrentSettings();
            }
            else
            {
                return $"Current HostName:{this.HostName} - with port number: {this.PortNumber} selected: {SelectedSportTopic}";
            }
        }
    }
}
