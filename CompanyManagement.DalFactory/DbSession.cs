using CompanyManagement.EFDAL;
using CompanyManagement.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DalFactory
{
    public class DbSession:IDbSession
    {
        public ICompanyDal CompanyDal
        {
            get
            {
                return StaticDalFactory.GetCompanyDal();
            }
        }
        public IStoreDal StoreDal
        {
            get
            {
                return StaticDalFactory.GetStoreDal();
            }
        }
        public int SaveChanges()
        {
            return DbContextFactory.GetCurrentDbContext().SaveChanges();
        }

      
    }
}
