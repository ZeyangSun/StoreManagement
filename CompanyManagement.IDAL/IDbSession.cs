using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.IDAL
{
    public interface IDbSession
    {
        ICompanyDal CompanyDal { get; }
        IStoreDal StoreDal { get; }
        int SaveChanges();
    }
}
