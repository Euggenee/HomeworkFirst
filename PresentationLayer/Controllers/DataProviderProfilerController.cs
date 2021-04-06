using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DataProviderProfilerService;

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
        public ActionResult GetDataProviderProfiler()
        {
            _dataProviderProfilerService.ComparePerformance();
            return Ok();
        }
    }
}
