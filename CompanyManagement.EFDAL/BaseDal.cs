
using CompanyManagement.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Unity;
using Unity.Attributes;

namespace CompanyManagement.EFDAL
{
    //wrap the common crud methods
    public class BaseDal<T> where T : class, new()
    {
       
       public DbContext Db
        {
            get
            {
                return DbContextFactory.GetCurrentDbContext();
            }
        }
        //crud
        //DataModel Db = new DataModel();

        //
        //public List<T> GetAllCompanies()
        //{
        //    DataModel Db = new DataModel();
        //    return Db.Companies.ToList();

        //}
        //UnitTest----OK
        public IQueryable<T> GetEntitiesByCondition(Expression<Func<T, bool>> whereLambda)//delay the loading by using Expression
        {
            return Db.Set<T>().Where(whereLambda).AsQueryable();
        }
        public T FindById(Guid? Id)
        {
            return Db.Set<T>().Find(Id);
        }
        public IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total,
            Expression<Func<T, bool>> whereLambda,
            Expression<Func<T, S>> orderByLamda,
            bool isAsc)
        {
            total = Db.Set<T>().Where(whereLambda).Count();
            if (isAsc)
            {
                var temp = Db.Set<T>().Where(whereLambda)
                .OrderBy<T, S>(orderByLamda)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize).AsQueryable();
                return temp;
            }
            else
            {
                var temp = Db.Set<T>().Where(whereLambda)
                .OrderByDescending<T, S>(orderByLamda)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize).AsQueryable();
                return temp;
            }


        }
        public T Create(T entity)
        {
           
            Db.Set<T>().Add(entity);
            //Db.SaveChanges();
            return entity;
        }
        public bool Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            return true;
                //Db.SaveChanges() > 0;

        }
        public bool Delete(T entity)
        {
            Db.Entry(entity).State = EntityState.Deleted;
            return true;
                //Db.SaveChanges() > 0;
        }
        
        

    }
}