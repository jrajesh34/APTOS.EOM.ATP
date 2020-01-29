using ATP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATP.Interfaces
{
    public interface IATPService
    {
        IEnumerable<ATPTransaction> GetATPTransactions(int atpId);

        bool InsertATPTransactions(ATPTransaction aTPTransaction);

        bool UpdateATPTransactions(ATPTransaction aTPTransaction);

        bool DeleteATPTransactions(ATPTransaction aTPTransaction);
    }
}
