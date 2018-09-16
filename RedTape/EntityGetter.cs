using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RedTape.Model;

namespace RedTape
{
    public class EntityGetter
    {
        private const string EntityByNzbnUrlFormat = "https://sandbox.api.business.govt.nz/services/v3/nzbn/entities/{0}";

        public static async Task<string> Get(string nzbnString = "9429036563593")
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Environment.GetEnvironmentVariable("REDTAPE_ACCESS_TOKEN"));

                var url = string.Format(EntityByNzbnUrlFormat, nzbnString);

                try
                {
                    var response = await client.GetAsync(url);

                    Console.WriteLine("NZBN request status: " + response.StatusCode);

                    if (response.StatusCode == HttpStatusCode.OK && response.Content != null)
                    {
                        var nzbnResponse = await response.Content.ReadAsStringAsync();

                        Console.WriteLine(nzbnResponse);

                        var nzbnEntity = JsonConvert.DeserializeObject<NzbnEntity>(nzbnResponse);

                        return nzbnEntity.EntityName;
                    }
                    else
                    {
                        return "I didn't find a business using that number. Please make sure you're using a valid New Zealand Business Number.";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("NZBN request failed: " + ex.Message);
                }
            }

            return string.Empty;
        }
    }
}
