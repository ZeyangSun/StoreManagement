using System;
using System.Linq;
using CompanyManagement.EFDAL;
using CompanyManagement.IDAL;
using CompanyManagement.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject
{
    [TestClass]
    public class CompanyDalTest
    {
        //for the test reason, for this project, the test data will dependent 
        //on the real data in the database.
        [TestMethod]
        public void TestMethod1()
        {
            ICompanyDal companyDal = new CompanyDal();
            IQueryable<Company> temp=companyDal.GetEntitiesByCondition(boolValue => true);
            Assert.AreEqual(true, temp.Count() == 2);
        }
    }
}
