using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    /// <summary>
    /// History
    /// </summary>
    public class History
    {
        public int HistoryId { get; set; }
        public int SharesId { get; set; }
        public virtual Shares Shares { get; set; }
        public decimal Low { get; set; }
        public decimal High { get; set; }
        public decimal Close { get; set; }
        public decimal Open { get; set; }
        public DateTime DDate { get; set; }

    }
}
