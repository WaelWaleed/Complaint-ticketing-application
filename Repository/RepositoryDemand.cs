using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryDemand : Repository<Demand>, IRepositoryDemand
    {
        public RepositoryDemand(DBContext dBContext):base(dBContext)
        {
            
        }
    }
}
