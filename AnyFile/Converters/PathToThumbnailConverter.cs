using Asjc.ThumbnailProvider;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using static Asjc.Utils.Tryer;

namespace AnyFile.Converters
{
    public class PathToThumbnailConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not string path)
                return null;
            return Try(() =>
            {
                var hBitmap = ThumbnailProvider.GetHThumbnail(path);
                try
                {
                    var source = Imaging.CreateBitmapSourceFromHBitmap(
                        hBitmap,
                        IntPtr.Zero,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions());
                    source.Freeze();
                    return source;
                }
                finally
                {
                    ThumbnailProvider.DeleteObject(hBitmap);
                }
            });
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
