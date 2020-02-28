using System;
using System.Collections.Generic;

namespace APTOS.EOM.ATPService.ATPEFModels
{
    public partial class ServiceStatus
    {
        public ServiceStatus()
        {
            ItemDelivery = new HashSet<ItemDelivery>();
            ItemReservation = new HashSet<ItemReservation>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ItemDelivery> ItemDelivery { get; set; }
        public virtual ICollection<ItemReservation> ItemReservation { get; set; }
    }
}
