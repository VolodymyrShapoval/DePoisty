using System.ComponentModel;
using System.Runtime.Serialization;

namespace DePoisty.ParserService.Infrastructure.Common
{
    public class SeleniumParsingException : Exception
    {
        public SeleniumParsingException() : base() { }

        public SeleniumParsingException(string? message) : base(message) { }

        public SeleniumParsingException(string? message, Exception? innerException) : base(message, innerException) { }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
        protected SeleniumParsingException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
