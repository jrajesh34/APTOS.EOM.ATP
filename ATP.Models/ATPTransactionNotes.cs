using System;
using System.Collections.Generic;
using System.Text;

namespace ATP.Models
{
   public class ATPTransactionNotes
    {
        public Int64 ATPTransactionId { get; set; }
        public string Context { get; set; }
        public string NoteReferenceId { get; set; }
        public string Note { get; set; }
        public DateTime? CreatedDateTimeUtc { get; set; }
        public DateTime? UpdatedDateTimeUtc { get; set; }
    }
}
