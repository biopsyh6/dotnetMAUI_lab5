using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Kolesnikov.UI.ValueConverters
{
    public class IdToImageValueConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value is null)
            {
                return ImageSource.FromFile("No_image_available.svg.png");
            }
            var dirPath = "C:\\2kurs_2sem\\ISP\\LR5\\253504_Kolesnikov\\253504_Kolesnikov.UI\\Images\\";
            var pathToImage = Path.Combine(dirPath, $"{(int)value}.png");

            if (!File.Exists(pathToImage))
            { 
                pathToImage = Path.Combine(dirPath, $"{(int)value}.jpg");
            }
            if(!File.Exists(pathToImage))
            {
                pathToImage = Path.Combine(dirPath, $"{(int)value}.jpeg");
            }
            if(File.Exists(pathToImage))
            {
                return ImageSource.FromFile(pathToImage);
            }
            return ImageSource.FromFile("No_image_available.svg.png");
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
