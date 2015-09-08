using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace System
{
    internal static class ExtensionMethods
    {
        public static void Close(this Stream s)
        {
            s.Dispose();
        }
        public static void Close(this StreamWriter s)
        {
            s.Dispose();
        }
        public static bool StartsWith(this string str, bool ignoreCase, CultureInfo culture)
        {
            return str.StartsWith(str, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }
        public static bool EndsWith(this string str, bool ignoreCase, CultureInfo culture)
        {
            return str.EndsWith(str, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }
        public static double ToOADate(this DateTime d)
        {
            var value = d.Ticks;
            if (value == 0L)
            {
                return 0.0;
            }
            if (value < 864000000000L)
            {
                value += 599264352000000000L;
            }
            if (value < 31241376000000000L)
            {
                throw new OverflowException();
            }
            long num = (value - 599264352000000000L) / 10000L;
            if (num < 0L)
            {
                long num2 = num % 86400000L;
                if (num2 != 0L)
                {
                    num -= (86400000L + num2) * 2L;
                }
            }
            return (double)num / 86400000.0;
        }

        internal static DateTime FromOADate(double d)
        {
            return new DateTime(DoubleDateToTicks(d), DateTimeKind.Unspecified);
        }


        // System.DateTime
        internal static long DoubleDateToTicks(double value)
        {
            if (value >= 2958466.0 || value <= -657435.0)
            {
                throw new ArgumentException();
            }
            long num = (long)(value * 86400000.0 + ((value >= 0.0) ? 0.5 : -0.5));
            if (num < 0L)
            {
                long expr_5C = num;
                num = expr_5C - expr_5C % 86400000L * 2L;
            }
            num += 59926435200000L;
            if (num < 0L || num >= 315537897600000L)
            {
                throw new ArgumentException();
            }
            return num * 10000L;
        }


        public static string ToLower(this string str, CultureInfo c)
        {
            return c == CultureInfo.InvariantCulture ? str.ToLowerInvariant() : str.ToLower();
        }
        public static string ToUpper(this string str, CultureInfo c)
        {
            return c == CultureInfo.InvariantCulture ? str.ToUpperInvariant() : str.ToUpper();
        }

        public static byte[] GetBufferBorrowed(this MemoryStream ms)
        {
#if CORECLR
            ArraySegment<byte> b;
            if (ms.TryGetBuffer(out b)) return b.ToArray();
            throw new InvalidOperationException();
#else
            return ms.GetBuffer();
#endif
        }

        public static string ToString(this char ch, CultureInfo c)
        {
            return ch.ToString();
        }
    }
}
