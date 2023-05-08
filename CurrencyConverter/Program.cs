using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace CurrencyConverter
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        public static void GetAllTheCurrencies()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://cdn.jsdelivr.net/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Get Response from the api
            HttpResponseMessage response = client.GetAsync("gh/fawazahmed0/currency-api@1/latest/currencies.json").Result;

            if(response != null && response.IsSuccessStatusCode)
            {

                JsonNode? jObj = JsonObject.Parse(response.Content.ReadAsStringAsync().Result);

                string currencies = response.Content.ReadAsStringAsync().Result;
                using JsonDocument jsonDoc = JsonDocument.Parse(currencies);
                //var jObj = JsonObject.Parse(currencies);
                //var obj = jObj.AsObject();
                //var value = obj.Select;
            }
        }
    }
}