using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
   public class ApiRequestsLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string ResourceName { get; set; }
        public string EndpointName { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
