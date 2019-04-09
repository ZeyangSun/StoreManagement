using CompanyManagement.IBLL;
using CompanyManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BLL
{
    public class StoreService : BaseService<Store>, IStoreService
    {
        //public StoreService(StoreDal dal)
        //    :base(dal)
        //{

        //}
        public override void SetCurrentDal()
        {
            CurrentDal = this.DBSession.StoreDal;
        }
    }
}
