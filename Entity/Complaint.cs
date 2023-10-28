using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Complaint : BaseEntity
    {
        public string Description {  get; set; }
        public bool Approved { get; set; }
        public string UserName { get; set; }
        public string UserNumber { get; set; }
        public string Attachment { get; set; }
        public int UserID { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Demand>? Demands { get; set; }
    }
}
