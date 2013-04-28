using System.Collections.Generic;
using Newman.Domain.ViewModels;

namespace Newman.Domain
{
    public class DataRepo
    {
        public IEnumerable<PlaygroundIvm> GetPlaygrounds()
        {
            return new List<PlaygroundIvm>(
                new[]
                    {
                        new PlaygroundIvm()
                            {
                                Name = "Afrika",
                                Position = new Position(){Lat = 55.557337, Lng = 12.914515},
                                Type = "Temalekplats"
                            }, 
                    });
        }
    }
}