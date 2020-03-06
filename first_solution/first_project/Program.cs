using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace first_project
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var websiteUrl = args[0];
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(websiteUrl);
            if(response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                var emailAddresses = regex.Matches(htmlContent);
                foreach(var emailAddress in emailAddresses)
                {
                    Console.WriteLine("Email: {0}", emailAddress.ToString());
                }
            }
            Console.ReadKey();
        }
    }
}
