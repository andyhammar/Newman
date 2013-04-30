using System.Collections.Generic;
using System.Threading.Tasks;

namespace Newman.Domain.ViewModels
{
    public class MapVm : BaseVm
    {
        public MapVm()
        {
        }

        public IEnumerable<PlaygroundIvm> Playgrounds { get; set; }

        public async Task Init()
        {
            var dataRepo = new DataRepo();
            Playgrounds = await dataRepo.GetPlaygroundsAsync();
        }
    }
}