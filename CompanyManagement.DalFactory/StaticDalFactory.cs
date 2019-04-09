using CompanyManagement.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DalFactory
{
    public class StaticDalFactory
    {
        public static string assemblyName = System.Configuration.ConfigurationManager.AppSettings["DalAssemblyName"];
        public static ICompanyDal GetCompanyDal()
        {
            //return new CompanyDal();

            //return Assembly.Load("CompanyManagement.EFDAL").CreateInstance("CompanyManagement.EFDAL.CompanyDal")
            //as ICompanyDal;


            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".CompanyDal")
                as ICompanyDal;

        }
        public static IStoreDal GetStoreDal()
        {
            //return new StoreDal();

            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".StoreDal")
                as IStoreDal;
        }
    }
}
