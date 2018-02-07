using Domain.StoreContext.Enums;
using Shared.Entities;
using System;

namespace Domain.StoreContext.Entities
{
    public class Delivery : Entity
    {
        #region Constructor
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }
        #endregion

        #region Properties
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }
        #endregion

        #region Methods
        public void Ship() => Status = EDeliveryStatus.Shipped;

        public void Cancel() => Status = EDeliveryStatus.Canceled;
        #endregion
    }
}