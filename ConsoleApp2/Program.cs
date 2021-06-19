using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp2 {
    class Program {
        static void Main(string[] args) {
            ConsumirAPI();
        }

        private static void ConsumirAPI() {
            var url = $"https://ws.smn.gob.ar/map_items/weather";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try {
                using (WebResponse response = request.GetResponse()) {
                    using (Stream strReader = response.GetResponseStream()) {
                        if (strReader != null) {
                            using (StreamReader objReader = new StreamReader(strReader)) {
                                string responseBody = objReader.ReadToEnd();
                                List<Provincias> ListProvincias = JsonSerializer.Deserialize<List<Provincias>>(responseBody);
                                Console.WriteLine("Hola");
                                foreach (Provincias Prov in ListProvincias) { // No imprime nada xd, nisiquiera se imprime el "Hola" de arriba
                                    Console.WriteLine("Prov nombre: " + Prov.Name);
                                }
                            }
                        }
                    }
                }
            } catch {

            }
        }
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
        public class Weather {
            [JsonPropertyName("humidity")]
            public int Humidity { get; set; }

            [JsonPropertyName("pressure")]
            public double Pressure { get; set; }

            [JsonPropertyName("st")]
            public object St { get; set; }

            [JsonPropertyName("visibility")]
            public int Visibility { get; set; }

            [JsonPropertyName("wind_speed")]
            public int WindSpeed { get; set; }

            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("temp")]
            public double Temp { get; set; }

            [JsonPropertyName("wing_deg")]
            public string WingDeg { get; set; }

            [JsonPropertyName("tempDesc")]
            public string TempDesc { get; set; }
        }

        public class Provincias {
            [JsonPropertyName("_id")]
            public string Id { get; set; }

            [JsonPropertyName("dist")]
            public double Dist { get; set; }

            [JsonPropertyName("lid")]
            public int Lid { get; set; }

            [JsonPropertyName("fid")]
            public int Fid { get; set; }

            [JsonPropertyName("int_number")]
            public int IntNumber { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("province")]
            public string Province { get; set; }

            [JsonPropertyName("lat")]
            public string Lat { get; set; }

            [JsonPropertyName("lon")]
            public string Lon { get; set; }

            [JsonPropertyName("zoom")]
            public string Zoom { get; set; }

            [JsonPropertyName("updated")]
            public int Updated { get; set; }

            [JsonPropertyName("weather")]
            public Weather Weather { get; set; }

            [JsonPropertyName("forecast")]
            public object Forecast { get; set; }
        }

    }
}
