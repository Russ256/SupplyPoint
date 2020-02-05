namespace SupplyPoint.Domain.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IRepository<T> where T : IAggregateRoot
    {
    }
}
