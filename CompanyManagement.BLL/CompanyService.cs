﻿
using CompanyManagement.DalFactory;
using CompanyManagement.EFDAL;
using CompanyManagement.IDAL;
using CompanyManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BLL
{

    public class CompanyService : BaseService<Company>
    {

        //ICompanyDal companyDal = StaticDalFactory.GetCompanyDal();
        //IDbSession dbSession = DbSessionFactory.GetCurrentDbSession();
        //public Company AddCompany(Company company)
        //{
        //    if (dbSession.SaveChanges() > 0)
        //    {

        //    }
        //    return dbSession.CompanyDal.Create(company);
        //}
        public override void SetCurrentDal()
        {
            CurrentDal = this.DBSession.CompanyDal;
        }
    }
}