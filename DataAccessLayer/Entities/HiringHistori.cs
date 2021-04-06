using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{

    public class HiringHistori
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<Achievement> Achievements { get; set;}
        public string EmployeId { get; set; }
    }
}
