using Microsoft.EntityFrameworkCore;
using SalesSystem.DTOs.Common;
using SalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesSystem.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly LESAContext lESAContext;

        public GenericRepository(LESAContext lESAContext)
        {
            this.lESAContext = lESAContext;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if(entity == null)
            {
                throw new Exception("The entity is null");
            }
            lESAContext.Set<TEntity>().Remove(entity);
            await lESAContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await lESAContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await lESAContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            lESAContext.Set<TEntity>().Add(entity);
            await lESAContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpDate(TEntity entity)
        {
            //lESAContext.Entry(entity).State = EntityState.Modified;
            //lESAContext.Set<TEntity>().AddOrUpdate(entity);
            //lESAContext.Set<TEntity>().Update(entity);
            await lESAContext.SaveChangesAsync();
            return entity;
        }
    }
}
