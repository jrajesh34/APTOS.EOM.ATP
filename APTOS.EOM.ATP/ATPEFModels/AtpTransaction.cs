using System;
using System.Collections.Generic;

namespace APTOS.EOM.ATPService.ATPEFModels
{
    public partial class AtpTransaction
    {
        public AtpTransaction()
        {
            AtpItem = new HashSet<AtpItem>();
            AtpTransactionNotes = new HashSet<AtpTransactionNotes>();
        }

        public long AtpTransactionId { get; set; }
        public long? Cartexternalid { get; set; }
        public int? Orderinternalid { get; set; }
        public decimal? Totaldeliverycost { get; set; }
        public string SalesChannelData { get; set; }
        public string LogisticsData { get; set; }
        public DateTime CreateDatetimeUtc { get; set; }
        public DateTime UpdateDatetimeUtc { get; set; }

        public virtual ICollection<AtpItem> AtpItem { get; set; }
        public virtual ICollection<AtpTransactionNotes> AtpTransactionNotes { get; set; }
    }
}
