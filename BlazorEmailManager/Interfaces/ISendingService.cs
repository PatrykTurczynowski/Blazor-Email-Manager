using BlazorEmailManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmailManager.Interfaces
{
    public interface ISendingService
    {
        public void SendEmails(EmailDraft email, IList<string> receivers);
    }
}
