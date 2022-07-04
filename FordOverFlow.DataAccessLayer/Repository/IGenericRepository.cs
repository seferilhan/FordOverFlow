﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordOverFlow.DataAccessLayer.Repository
{
    public interface IGenericRepository <T> where T : class
    {
        void Update(T entity);
        void Insert(T entity);
        void Delete(long Id);
        void DeleteAll();
        T GetById(long Id);
        IEnumerable<T> GetAll();

    }
}
