using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DataProviderProfilerService;
using BusinessLogicLayer.Models;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataProviderProfilerController : ControllerBase
    {
        private readonly IDataProviderProfilerService _dataProviderProfilerService;
       public DataProviderProfilerController(IDataProviderProfilerService dataProviderProfilerService)
        {
            _dataProviderProfilerService = dataProviderProfilerService;
        }

        [HttpGet]
        [Route("get-dataProviderProfiler")]
        public ActionResult<LeadTime> GetDataProviderProfiler()
        {
           var leadTime = _dataProviderProfilerService.ComparePerformance();
            if (leadTime.LinqMethodLeadTime != 0 && leadTime.RawSQLQueryLeadTime != 0)
            {
                return Ok(leadTime);
            }
            return BadRequest();
            
        }
    }
}
