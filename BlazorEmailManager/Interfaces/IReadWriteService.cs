using BlazorEmailManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmailManager.Interfaces
{
    public interface IReadWriteService
    {
        public IEnumerable<Email> ReadFile(string filepath);
        public Task SaveFileAsync(IEnumerable<Email> emails);
    }
}
