using System.Collections.Generic;

namespace Newman.Domain.ViewModels
{
    public class MapVm
    {
        public MapVm()
        {
            Playgrounds = new DataRepo().GetPlaygrounds();
        }

        public IEnumerable<PlaygroundIvm> Playgrounds { get; set; } 
    }
}