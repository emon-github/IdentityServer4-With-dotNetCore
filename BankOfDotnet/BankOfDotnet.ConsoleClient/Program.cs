using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BankOfDotnet.ConsoleClient
{
    class Program
    {
        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            var discoveryClient = new DiscoveryClient("http://localhost:5000");
            var doc = await discoveryClient.GetAsync();

            if (doc.IsError)
            {
                Console.WriteLine(doc.Error);
                return;
            }

            var tokenClient = new TokenClient(doc.TokenEndpoint, "Client", "Secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("bankOfDotnetApi");

            if(tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");

            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);


            var customerInfo = new StringContent(
                JsonConvert.SerializeObject(
                    new { id = 5, Firstname = "Anik", LastName = "Datta" }), Encoding.UTF8, "application/json"
                );

            var createCustomerResponse = await client.PostAsync("http://localhost:49961/api/customers",customerInfo);

            if (!createCustomerResponse.IsSuccessStatusCode)
            {
                Console.WriteLine(createCustomerResponse.StatusCode);
            }


            var getCustomerResponse = await client.GetAsync("http://localhost:49961/api/customers");
            if (!getCustomerResponse.IsSuccessStatusCode)
            {
                Console.WriteLine(getCustomerResponse.StatusCode);
            }
            else
            {
                var content = await getCustomerResponse.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }

            Console.Read();
        }
    }
}
