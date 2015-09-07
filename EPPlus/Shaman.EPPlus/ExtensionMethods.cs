using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeOpenXml
{
    internal static class ExtensionMethods
    {
        public static void Close(this Stream s)
        {
            s.Dispose();
        }
    }
}
