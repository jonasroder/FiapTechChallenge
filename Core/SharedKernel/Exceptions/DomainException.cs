using System.Runtime.Serialization;

namespace Core.SharedKernel.Exceptions
{
    [Serializable]
    public class DomainException : Exception
    {
        public string? ErrorCode { get; }

        public DomainException()
        {
        }

        public DomainException(string message)
            : base(message)
        {
        }

        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DomainException(string errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public DomainException(string errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

        // Construtor necessário para desserialização de exceções remotas/loggers
        protected DomainException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ErrorCode = info.GetString(nameof(ErrorCode));
        }

        // Garante que ErrorCode seja serializado também
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info is null) throw new ArgumentNullException(nameof(info));
            info.AddValue(nameof(ErrorCode), ErrorCode);
            base.GetObjectData(info, context);
        }
    }
}
