using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RedTape.Model;

namespace RedTape
{
    public class EntityGetter
    {
        private const string EntityByNzbnUrlFormat = "https://api.business.govt.nz/services/v3/nzbn/entities/{0}";

        public static async Task<string> Get(string nzbnString = "9429036563593")
        {
            using (var client = new HttpClient())
            {
                var accessToken = Environment.GetEnvironmentVariable("REDTAPE_ACCESS_TOKEN");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

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

                        return BuildResponse(nzbnEntity);
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

        private static string BuildResponse(NzbnEntity nzbnEntity)
        {
            var responseBuilder = new StringBuilder();

            responseBuilder.Append(string.Format("That New Zealand Business Number is for the entity {0}", nzbnEntity.EntityName));

            if (!string.IsNullOrWhiteSpace(nzbnEntity.EntityTypeDescription))
            {
                responseBuilder.Append(string.Format(", which is a {0}. ", nzbnEntity.EntityTypeDescription));
            }
            else { responseBuilder.Append(". "); }

            if (nzbnEntity.RegistrationDateTime.HasValue && nzbnEntity.RegistrationDateTime.Value != DateTime.MinValue)
            {
                responseBuilder.Append(string.Format("The entity was registered on {0}. ", nzbnEntity.RegistrationDateTime.Value.ToString("D")));
            }

            if (nzbnEntity.RegisteredAddress != null && nzbnEntity.RegisteredAddress.Count > 0)
            {
                var current = nzbnEntity.RegisteredAddress.OrderByDescending(a => DateTime.Parse(a["startDate"])).FirstOrDefault();

                if (current != null)
                {
                    responseBuilder.Append(string.Format("The registered address of the entity is {0}, {1}, {2}, {3}. ", 
                        current["address1"], 
                        current["address2"], 
                        current["address3"], 
                        current["address4"]));
                }
            }

            return responseBuilder.ToString().Replace(" NZ ", " New Zealand ");
        }
    }
}
