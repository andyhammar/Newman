using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newman.Domain.ViewModels;
using Newtonsoft.Json.Linq;

namespace Newman.Domain
{
    public class DataRepoStockholm : IDataRepo
    {
        public async Task<IEnumerable<PlaygroundIvm>> GetPlaygroundsAsync()
        {
            var client = new HttpClient();
            var json =
                await
                client.GetStringAsync(
                    "http://api.stockholm.se/ServiceGuideService/ServiceUnitTypes/9da341e4-bdc6-4b51-9563-e65ddc2f7434/ServiceUnits/json?apikey=c4cd291daef84b1aa6c95d3287d11ba4");

            var result = JArray.Parse(json).Select(CreatePlaygroundIvm);
            return result;
        }

        private PlaygroundIvm CreatePlaygroundIvm(JToken jToken)
        {
            var geoService = new GeoService();

            var x = (string)jToken["GeographicalPosition"]["X"];
            var y = (string)jToken["GeographicalPosition"]["Y"];

            return new PlaygroundIvm
                {
                    Name = (string)jToken["Name"],
                    Position = geoService.GetPositionFromRt90(x, y)
                };

        }
   }
}