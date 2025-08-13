using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;

namespace AnyFile.Converters
{
    public class EnumToDisplayNameConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            Type type = value.GetType();
            if (type.IsEnum)
            {
                MemberInfo[] infos = type.GetMember(value.ToString());
                if (infos.Length > 0)
                {
                    DisplayAttribute? attr = infos[0].GetCustomAttribute<DisplayAttribute>();
                    if (attr != null)
                        return attr.Name;
                }
            }
            return value.ToString();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
