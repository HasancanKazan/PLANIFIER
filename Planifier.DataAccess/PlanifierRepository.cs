﻿using Planifier.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planifier.DataAccess
{
    public class PlanifierRepository<T> : IPlanifierRepository<T> where T : class
    {
        private readonly PlanifierDatabaseContext _dbContext;
        private readonly DbSet<T> _dbSet;


        public PlanifierRepository(PlanifierDatabaseContext databaseContext)
        {
            _dbContext = databaseContext; //PlanifierRepositoryBase.CreateContext();
            _dbSet = _dbContext.Set<T>();
        }
        

        public int Insert(T obj)
        {
            _dbSet.Add(obj);
            return _dbContext.SaveChanges();
        }
        public int Update(T obj)
        {
            _dbSet.Add(obj);
            return _dbContext.SaveChanges();
        }
        public int Delete(T obj)
        {
            _dbSet.Remove(obj);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }

        public  IEnumerable<T> FindAll()
        {
            return  _dbSet.ToList();
        }

        public async Task<T> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> FindOne(Expression<Func<T, bool>> where)
        {
            return await _dbSet.FirstOrDefaultAsync(where);
        }

        public void Add(T obj)
        {
            _dbSet.Add(obj);
        }
    }
}
