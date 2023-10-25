using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _dbContext;
        
        public IRepositoryUser User { get; set; }

        public IRepositoryUserType UserType { get; set; }

        public IRepositoryComplaint Complaint { get; set; }

        public IRepositoryDemand Demand { get; set; }

        public UnitOfWork(DBContext dBContext)
        {
            _dbContext = dBContext;
            User = new RepositoryUser(dBContext);
            UserType = new RepositoryUserType(dBContext);
            Complaint = new RepositoryComplaint(dBContext);
            Demand = new RepositoryDemand(dBContext);
        }

        public void Complete()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
