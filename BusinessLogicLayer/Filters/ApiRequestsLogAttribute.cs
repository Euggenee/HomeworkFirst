using DataAccessLayer;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;


namespace BusinessLogicLayer.Filters
{
   public class ApiRequestsLogAttribute : ActionFilterAttribute 
    {
        
        private readonly IApplicationDbContext _dbContext;
        public ApiRequestsLogAttribute(IApplicationDbContext dbContext) // Здесь пройдет инициал. благодаря механизму адд скопе класса стартап
        {
            _dbContext = dbContext;
        }
        public override void OnActionExecuting(ActionExecutingContext context) 
        {
           
            var deskriptor = context.ActionDescriptor as Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor;

            DataAccessLayer.Entities.ApiRequestsLog apiRequestsLog = new DataAccessLayer.Entities.ApiRequestsLog()
            {
                EndpointName = deskriptor.ActionName.ToString(),
                ResourceName = deskriptor.ControllerName.ToString(),
                RequestTime = DateTime.UtcNow
            };

            _dbContext.ApiRequestsLogs.Add(apiRequestsLog);
            _dbContext.SaveChanges();


            base.OnActionExecuting(context);
        }
    }
}
