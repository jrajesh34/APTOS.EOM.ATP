using System.Diagnostics.CodeAnalysis;
using log4net.Layout;
using log4net.Util;

namespace ATP.Logging
{
    [ExcludeFromCodeCoverage]
    public class CustomPatternLayout : PatternLayout
    {
        public CustomPatternLayout()
        {
            AddConverter(new ConverterInfo
            {
                Name = "encodedmessage",
                Type = typeof(EncodedMessagePatternConverter)
            });
        }
    }
}
