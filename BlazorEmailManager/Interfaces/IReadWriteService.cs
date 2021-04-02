using BlazorEmailManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorEmailManager.Interfaces
{
    public interface IReadWriteService
    {
        public IEnumerable<Email> ReadFile(string filepath);
        public Task SaveFileAsync(IEnumerable<Email> emails);
    }
}
