using BlazorEmailManager.Interfaces;
using BlazorEmailManager.Models;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmailManager.Services
{
    public class ReadWriteService : IReadWriteService
    {
        private readonly IJSRuntime jsRuntime;

        public ReadWriteService(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public IEnumerable<Email> ReadFile(string filepath)
        {
            ICollection<Email> emails = new List<Email>();

            string[] allLines = filepath.Split(new[] { Environment.NewLine }, StringSplitOptions.None).SkipLast(1).ToArray();
            bool isProperFile = allLines[0].Contains(nameof(Email.EmailAddress));

            if (isProperFile == true)
            {
                foreach (var item in allLines.Skip(1))
                {
                    string[] row = item.Split(',');
                    emails.Add(new Email(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7]));
                }
            }

            return emails;
        }

        public async Task SaveFileAsync(IEnumerable<Email> emails)
        {
            using (var stringWriter = new StringWriter())
            {
                var headers = string.Join(",",
                    nameof(Email.EmailAddress),
                    nameof(Email.FirstName),
                    nameof(Email.LastName),
                    nameof(Email.Country),
                    nameof(Email.Organization),
                    nameof(Email.Department),
                    nameof(Email.Position),
                    nameof(Email.PhoneNumber));

                stringWriter.WriteLine(headers);

                foreach (var email in emails)
                {
                    var line = string.Join(',', email.EmailAddress, email.FirstName, email.LastName, email.Country, email.Organization, email.Department, email.Position, email.PhoneNumber);
                    stringWriter.WriteLine(line);
                }

                stringWriter.Close();

                byte[] file = System.Text.Encoding.UTF8.GetBytes(stringWriter.ToString());
                await jsRuntime.InvokeAsync<object>("saveAsFile", $"emails-{DateTime.UtcNow}.csv", Convert.ToBase64String(file));
            }
        }
    }
}
