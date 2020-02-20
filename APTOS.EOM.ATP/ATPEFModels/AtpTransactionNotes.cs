using System;
using System.Collections.Generic;

namespace APTOS.EOM.ATPService.ATPEFModels
{
    public partial class AtpTransactionNotes
    {
        public long AtpTransactionNotesId { get; set; }
        public long AtpTransactionId { get; set; }
        public string Context { get; set; }
        public string NoteReferenceId { get; set; }
        public string Note { get; set; }
        public DateTime? CreateDatetimeUtc { get; set; }
        public DateTime? UpdateDatetimeUtc { get; set; }

        public virtual AtpTransaction AtpTransaction { get; set; }
    }
}
