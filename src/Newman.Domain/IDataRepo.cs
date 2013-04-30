using System.Collections.Generic;
using System.Threading.Tasks;
using Newman.Domain.ViewModels;

namespace Newman.Domain
{
    public interface IDataRepo
    {
        Task<IEnumerable<PlaygroundIvm>> GetPlaygroundsAsync();
    }
}