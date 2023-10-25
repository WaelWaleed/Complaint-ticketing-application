using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public int TypeID { get; set; }
        public virtual UserType? UserType { get; set; }
        public virtual ICollection<Complaint>? Complaints { get; set; }
    }

}
