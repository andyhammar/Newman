using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Newman.Win.Converters
{
    public static class Extensions
    {
        public static SolidColorBrush ToBrush(this Color color)
        {
            return new SolidColorBrush(color);
        }
    }
}