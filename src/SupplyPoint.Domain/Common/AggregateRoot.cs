namespace SupplyPoint.Domain.Common
{
    using System;

    /// <summary>
    /// Base class for any aggregate root classes.
    /// </summary>
    public abstract class AggregateRoot
    {
        private Guid id;

        public virtual Guid Id
        {
            get
            {
                return this.id;
            }
            protected set
            {
                this.id = value;
            }
        }
    }
}