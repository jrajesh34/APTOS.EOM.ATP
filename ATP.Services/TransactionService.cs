using ATP.Interfaces;
using ATP.Models;
using ATP.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATP.Services
{
    public class TransactionService : IATPService
    {
        public IEnumerable<ATPTransaction> GetATPTransactions(int atpId)
        {
            throw new NotImplementedException();
        }

        public bool InsertATPTransactions(ATPTransaction aTPTransactions)
        {
            throw new NotImplementedException();
        }

        public bool UpdateATPTransactions(ATPTransaction aTPTransaction)
        {
            throw new NotImplementedException();
        }

        public bool DeleteATPTransactions(ATPTransaction aTPTransaction)
        {
            throw new NotImplementedException();
        }

        public bool ProcessATPRequest(ATPRequest atpRequest)
        {
            switch(atpRequest.ActionType)
            {
                case ActionType.CREATE:
                    {
                        //TODO logic to be written
                        break;
                    }
                case ActionType.UPDATE:
                    {
                        //TODO logic to be written
                        break;
                    }
                case ActionType.CONFIRM:
                    {
                        //TODO logic to be written
                        break;
                    }
                case ActionType.CANCEL:
                    {
                        //TODO logic to be written
                        break;
                    }
            }
            return true;
        }
    }
}
