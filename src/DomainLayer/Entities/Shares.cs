using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    /// <summary>
    /// shares entity
    /// </summary>
    public class Shares
    {
        public int SharesId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }


    }
}
