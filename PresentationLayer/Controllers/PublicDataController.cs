using BusinessLogicLayer.Models;
using BusinessLogicLayer.PublicDataService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PresentationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublicDataController : ControllerBase
    {
        private readonly IPublicDataService _publicData;
        public PublicDataController(IPublicDataService publicData) // Здесь пройдет инициал. благодаря механизму адд скопе класса стартап
        {
            _publicData = publicData;
        }

        [HttpGet]
        [Route("data")]
        public List<PublicData> GetData()
        {
             return _publicData.GetPublicData();
        }
    }
}
