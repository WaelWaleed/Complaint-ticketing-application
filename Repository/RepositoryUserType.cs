using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryUserType:Repository<UserType>, IRepositoryUserType
    {
        public RepositoryUserType(DBContext dBContext):base(dBContext)
        {
        }
    }
}
