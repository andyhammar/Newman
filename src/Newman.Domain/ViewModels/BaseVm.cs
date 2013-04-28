using System.ComponentModel;

namespace Newman.Domain.ViewModels
{
    public class BaseVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}