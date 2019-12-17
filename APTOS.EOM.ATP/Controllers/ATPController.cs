using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APTOS.EOM.ATPService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATPController : ControllerBase
    {
        [Authorize]
        [HttpPost]
        public ATPResponse GetDeliveryDate([FromBody] ATPRequest value)
        {
            ATPResponse atpResponse = new ATPResponse();
            //Call to Logistics or AGENDA to get DW and Cost
            return atpResponse;
        }
    }
}