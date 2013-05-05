using System;
using System.Globalization;
using System.Windows.Data;
using Newman.Domain.ViewModels;

namespace Newman.Wp
{
    public class PositionToLocationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var position = value as Position;
            var result = new System.Device.Location.GeoCoordinate(position.Lat, position.Lng);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}