using System;

namespace OfficeOpenXml
{
    internal class Converter
    {
        private Type fromType;

        public Converter(Type fromType)
        {
            this.fromType = fromType;
        }

        internal bool CanConvertTo(Type type)
        {
            throw new NotImplementedException();
        }

        internal object ConvertTo(object v, Type type)
        {
            throw new NotImplementedException();
        }
    }
}