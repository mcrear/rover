using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rover.Main.Extensions
{
    public static class EnumExtensions
    {
        public static T ToEnumValue<T>(this string value) where T : Enum
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            catch
            {
                Console.WriteLine("Set rover start position '{0}' failed.", value);
                return (T)Enum.Parse(typeof(T), "F");
            }
        }
        public static T ToEnumValue<T>(this char value) where T : Enum
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value.ToString());
            }
            catch
            {
                Console.WriteLine("Set rover start position '{0}' failed.", value);
                return (T)Enum.Parse(typeof(T), "F");
            }
        }
    }
}
