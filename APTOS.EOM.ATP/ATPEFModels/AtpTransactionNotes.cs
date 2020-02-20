using System;
using System.Collections.Generic;

namespace APTOS.EOM.ATPService.ATPEFModels
{
    public partial class AtpTransactionNotes
    {
        public long AtpTransactionNotesId { get; set; }
        public long AtpTransactionId { get; set; }
        public string Atptranscontext { get; set; }
        public long? NoteReferenceId { get; set; }
        public string Atptransnote { get; set; }
        public DateTime CreateDatetimeUtc { get; set; }
        public DateTime UpdateDatetimeUtc { get; set; }

        public virtual AtpTransaction AtpTransaction { get; set; }
    }
}
