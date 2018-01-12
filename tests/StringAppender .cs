using log4net.Appender;
using log4net.Core;
using System.Text;

namespace log4net.Tests
{
    public class StringAppender : AppenderSkeleton
    {
        private readonly StringBuilder _builder = new StringBuilder();

        protected override void Append(LoggingEvent loggingEvent)
        {
            _builder.Append(RenderLoggingEvent(loggingEvent));
        }

        protected override bool RequiresLayout => true;

        public override string ToString()
        {
            return _builder.ToString();
        }

        public void Reset()
        {
            _builder.Length = 0;
        }

    }
}
