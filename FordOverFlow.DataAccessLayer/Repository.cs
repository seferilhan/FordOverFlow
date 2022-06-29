using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.DataAccessLayer
{
    public class Repository<T> where T : class                        //_db Controller'dan gelmekte. Farklı yaklaşım düşünülmeli.
                                                                      //Unit of Work ve Generic Repository Birleşimi incele
    {                                                                 //Bu ikisini Dependency İnjection ile kullanmayı dene


        //private readonly DatabaseContext _db;

        //public Repository(DatabaseContext db)
        //{
        //    _db = db;
        //}

        public List<T> List(DatabaseContext _db, Expression<Func<T, bool>> where)
        {
            return _db.Set<T>().Where(where).ToList();
        }

        public List<T> List(DatabaseContext _db)         //Tüm Tabloya List
        {
            return _db.Set<T>().ToList();
        }

        public int Save(DatabaseContext _db)
        {
            return _db.SaveChanges();
        }

        public int Insert(DatabaseContext _db, T obj)
        {
            _db.Set<T>().Add(obj);
            return Save(_db);
        }

        public int Update(DatabaseContext _db, T obj)
        {
            return Save(_db);
        }

        public int Delete(DatabaseContext _db, T obj)
        {
            _db.Set<T>().Remove(obj);
            return Save(_db);
        }

        public T Find(DatabaseContext _db,Expression<Func<T, bool>> where)
        {
            return _db.Set<T>().FirstOrDefault(where);
        }
    }
}
