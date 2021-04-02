using BlazorEmailManager.Models;
using System.Collections.Generic;

namespace BlazorEmailManager.Interfaces
{
    public interface ISendingService
    {
        public void SendEmails(EmailDraft email, IList<string> receivers);
    }
}
