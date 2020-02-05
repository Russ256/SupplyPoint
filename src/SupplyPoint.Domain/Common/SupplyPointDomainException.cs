namespace SupplyPoint.Domain.Common
{
    using System;

    public class SupplyPointDomainException : Exception
    {
        public SupplyPointDomainException()
        {
        }

        public SupplyPointDomainException(string message) : base(message)
        {
        }

        public SupplyPointDomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}