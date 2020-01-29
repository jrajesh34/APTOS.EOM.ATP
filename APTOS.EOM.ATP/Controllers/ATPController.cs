using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATP.Models;
using ATP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APTOS.EOM.ATPService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATPController : ControllerBase
    {
        TransactionService transactionService = null;
        [Authorize]
        [HttpPost]
        public ATPResponse ProcessATPRequest([FromBody] ATPRequest value)
        {
            ATPResponse atpResponse = new ATPResponse();
            //call to business logic layer to process input request based on ActionType
            transactionService = new TransactionService();

            transactionService = new TransactionService();

            transactionService = new TransactionService();

            transactionService = new TransactionService();

            //Call to Logistics or AGENDA to get DW and Cost to be implemented
            return atpResponse;
        }

        [Authorize]
        [HttpPost]
        public bool InsertATPTransactions([FromBody] ATPTransaction value)
        {
            transactionService = new TransactionService();
            //Call to business logic layer to insert record in ATP table
            transactionService.InsertATPTransactions(value);
            return true;
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<ATPTransaction> GetATPTransactions([FromBody] int value)
        {
            transactionService = new TransactionService();
            //Call to business logic layer to insert record in ATP table
            transactionService.GetATPTransactions(value);
            return new List<ATPTransaction>();
        }

        [Authorize]
        [HttpPost]
        public bool UpdateATPTransactions([FromBody] ATPTransaction value)
        {
            transactionService = new TransactionService();
            //Call to business logic layer to insert record in ATP table
            transactionService.UpdateATPTransactions(value);
            return true;
        }

        [Authorize]
        [HttpPost]
        public bool DeleteATPTransactions([FromBody] ATPTransaction value)
        {
            transactionService = new TransactionService();
            //Call to business logic layer to insert record in ATP table
            transactionService.DeleteATPTransactions(value);
            return true;
        }
    }
}