using System.Diagnostics.CodeAnalysis;
using System.IO;
using log4net.Core;
using log4net.Util;
namespace ATP.Logging
{
    [ExcludeFromCodeCoverage]
    public class EncodedMessagePatternConverter : PatternConverter
    {
        protected override void Convert(TextWriter writer, object state)
        {
            if (!(state is LoggingEvent loggingEvent)) return;

            var encodedMessage = loggingEvent.RenderedMessage
                .Replace("\r", " ").Replace("\n", " ");
            writer.Write(encodedMessage);
        }
    }
}
