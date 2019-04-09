using CompanyManagement.DalFactory;
using CompanyManagement.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BLL
{
    public abstract class BaseService<T> where T:class ,new()

    {
        public IDbSession DBSession
        {
            get
            {
                return DbSessionFactory.GetCurrentDbSession();
            }
        }
            
        public IBaseDal<T> CurrentDal
        {
            get;set;
        }
        public BaseService()
        {
            SetCurrentDal();
        }
        public abstract void SetCurrentDal();//child must implement this method
        public IQueryable<T> GetEntitiesByCondition(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.GetEntitiesByCondition(whereLambda);
        }
        public IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total,
            Expression<Func<T, bool>> whereLambda,
            Expression<Func<T, S>> orderByLamda,
            bool isAsc)
        {
            return CurrentDal.GetPageEntities(pageSize,pageIndex,out total,whereLambda,orderByLamda,isAsc);
        }
        public T Add(T entity)
        {
            CurrentDal.Create(entity);
            DBSession.SaveChanges();
            return entity;
        }
        
        public bool Update(T entity)
        {
             CurrentDal.Update(entity);
            return DBSession.SaveChanges() > 0;
        }
        public bool Delete(T entity)
        {
            CurrentDal.Delete(entity);
            return DBSession.SaveChanges() > 0;
        }
    }
}
