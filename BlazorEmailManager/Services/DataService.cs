using BlazorEmailManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmailManager.Services
{
    public class DataService
    {
        public IList<Email> Emails { get; set; }
    }
}
