using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newman.Domain.ViewModels
{
    public class MapVm : BaseVm
    {
        public MapVm()
        {
        }

        public IEnumerable<PlaygroundIvm> Playgrounds { get; set; }

        public Position Center { get; set; }

        public async Task Init()
        {
            var dataRepo = new DataRepoMalmo();
            Playgrounds = await dataRepo.GetPlaygroundsAsync();

            UpdateCenter();
        }

        private void UpdateCenter()
        {
            var latAvg = Playgrounds.Average(p => p.Position.Lat);
            var lngAvg = Playgrounds.Average(p => p.Position.Lng);

            Center = new Position { Lat = latAvg, Lng = lngAvg };
        }
    }
}