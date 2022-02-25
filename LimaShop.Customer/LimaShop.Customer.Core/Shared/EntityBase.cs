using System;

namespace LimaShop.Customer.Core.Shared
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
            UpdateAt = null;
        }

        public Guid Id { get; private set; }
        public DateTime CreateAt { get; private set; }
        public DateTime? UpdateAt { get; private set; }

        public void UpdateOnDate()
        {
            UpdateAt = DateTime.Now;
        }
    }
}
