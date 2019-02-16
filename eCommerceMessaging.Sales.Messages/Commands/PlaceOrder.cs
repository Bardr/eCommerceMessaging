using System;

namespace eCommerceMessaging.Sales.Messages.Commands
{
    public class PlaceOrder
    {
        public string UserId { get; set; }
        public string[] ProductIds { get; set; }
        public string ShippingTypeId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}