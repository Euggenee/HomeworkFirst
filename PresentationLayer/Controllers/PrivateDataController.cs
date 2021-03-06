using BusinessLogicLayer.Filters;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.PrivateDataService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PresentationLayer.Controllers
{


    [Route("[controller]")]
    [ApiController]
    public class PrivateDataController : ControllerBase
    {
        private readonly IPrivateDataService _privateData;

        public PrivateDataController(IPrivateDataService privateData) // Здесь пройдет инициал. благодаря механизму адд скопе класса стартап
        {
            _privateData = privateData;
        }

        [HttpGet]
        [Authorize]
        [Route("data")]
       /* [ServiceFilter(typeof(ApiRequestsLogAttribute))]*/
        public IActionResult GetData()
        {
            var data = _privateData.GetPrivateData();
            if (data == null) 
            {
                return BadRequest();
            }
            return Ok(data);
        }

    }
}
