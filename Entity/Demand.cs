using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Demand : BaseEntity
    {
        public string Description { get; set; }
        public int ComplaintID { get; set; }
        public virtual Complaint? Complaint { get; set; }
    }
}
