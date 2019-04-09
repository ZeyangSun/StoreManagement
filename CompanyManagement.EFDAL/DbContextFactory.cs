using CompanyManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.EFDAL
{
    public class DbContextFactory
    {
        public static DbContext GetCurrentDbContext()
        {
            //return new DataModel();
            DbContext db=CallContext.GetData("DbContext") as DbContext;
            if (db == null)
            {
                db = new DataModel();
                CallContext.SetData("DbContext", db);
            }
            return db;
        }
    }
}
