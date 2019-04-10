
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using CompanyManagement.IDAL;
using CompanyManagement.Model;

namespace CompanyManagement.EFDAL
{
    
    public class CompanyDal: BaseDal<Company>, ICompanyDal
    {
       // //crud
       // DataModel db = new DataModel();
       // //public List<Company> GetAllCompanies()
       // //{
       // //    DataModel db = new DataModel();
       // //    return db.Companies.ToList();
            
       // //}
       // //UnitTest----OK
       // public IQueryable<Company> GetCompaniesByCondition(Expression<Func<Company,bool>> whereLambda)//delay the loading by using Expression
       // {
       //     return db.Companies.Where(whereLambda).AsQueryable();
       // }
       // public IQueryable<Company> GetPageCompanies<S>(int pageSize,int pageIndex,out int total,
       //     Expression<Func<Company,bool>> whereLambda,
       //     Expression<Func<Company,S>> orderByLamda,
       //     bool isAsc)
       // {
       //     total = db.Companies.Where(whereLambda).Count();
       //     if (isAsc)
       //     {
       //         var temp = db.Companies.Where(whereLambda)
       //         .OrderBy<Company, S>(orderByLamda)
       //         .Skip(pageSize * (pageIndex - 1))
       //         .Take(pageSize).AsQueryable();
       //         return temp;
       //     }
       //     else
       //     {
       //         var temp = db.Companies.Where(whereLambda)
       //         .OrderByDescending<Company,S>(orderByLamda)
       //         .Skip(pageSize * (pageIndex - 1))
       //         .Take(pageSize).AsQueryable();
       //         return temp;
       //     }
            
           
       // }
       // public Company Create(Company company)
       // {
       //     db.Companies.Add(company);
       //     db.SaveChanges();
       //     return company;
       // }
       //public bool Edit(Company company)
       // {
       //     db.Entry(company).State = EntityState.Modified;
       //     return db.SaveChanges()>0 ;
            
       // }
       //public bool Delete(Company company)
       // {
       //     db.Entry(company).State = EntityState.Deleted;
       //     return db.SaveChanges() > 0;
       // }


    }
}
