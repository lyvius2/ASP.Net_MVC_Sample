using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppSample.Models
{
    public class Mountain
    {
        public int Id { get; set; }
        public string MountainName { get; set; }
        public string ClimbmingDate { get; set; }
        public string Comment { get; set; }
        public int Height { get; set; }
        public Boolean Complete { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdDate { get; set; }
    }
}
