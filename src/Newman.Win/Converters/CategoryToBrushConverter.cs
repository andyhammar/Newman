using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Newman.Win.Converters
{
    public class CategoryToBrushConverter : IValueConverter
    {
        static CategoryToBrushConverter()
        {
            CategoryToBrushDict = new Dictionary<string, SolidColorBrush>
                {
                    {"Nedlägges", 
                        Colors.Gray.ToBrush()},
                    {"Gym", 
                        Colors.GhostWhite.ToBrush()},
                    {"Närlekplats", 
                        Colors.DodgerBlue.ToBrush()},
                    {"Kvarterslekplats", 
                        Colors.YellowGreen.ToBrush()},
                    {"Temalekplats", 
                        Colors.OrangeRed.ToBrush()},
                    {"Stadsdelslekplats", 
                        Colors.DarkRed.ToBrush()},
                    {"Områdeslekplats", 
                        Colors.ForestGreen.ToBrush()},
                };
            DefaultBrush = Colors.DarkSlateBlue.ToBrush();
        }

        public static Dictionary<string, SolidColorBrush> CategoryToBrushDict;
        public static SolidColorBrush DefaultBrush;

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var text = value as string;
            if (text != null && CategoryToBrushDict.ContainsKey(text))
                return CategoryToBrushDict[text];
            return DefaultBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
