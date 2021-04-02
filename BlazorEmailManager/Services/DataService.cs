using BlazorEmailManager.Models;
using System.Collections.Generic;

namespace BlazorEmailManager.Services
{
    public class DataService
    {
        public IList<Email> Emails { get; set; }
    }
}
