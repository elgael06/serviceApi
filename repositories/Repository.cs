using serviceApi.interfaces;
using serviceApi.context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace serviceApi.repositories
{
    public class Repository<T>: IRepository<T> where T: class
    {
        public readonly ServicesDb contex;
        public bool disposed = false;

        public Repository(ServicesDb _context)
        {
            this.contex = _context;
        }

        public async Task Save()
        {
            await contex.SaveChangesAsync();
        }

        protected DbSet<T> EntitySet
        {
            get {
                return contex.Set<T>();
            }
        }

        // methods
        public async Task<IEnumerable<T>> GetAll()
        {
            return await EntitySet.ToListAsync();
        }
        public async Task<T> GetAllById(string id)
        {
            return await EntitySet.FindAsync(id);
        }
        public async Task<T> GetOneById(string id)
        {
            return await EntitySet.FindAsync(id);
        }
        public async Task<T> Insert(T entity)
        {
            
            await EntitySet.AddAsync(entity);
            await Save();
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            contex.Entry(entity).State = EntityState.Modified;
            await Save();
            return entity;
        }
        public async Task<T> Delete(string id)
        {
            T entity = await EntitySet.FindAsync(id);
            EntitySet.Remove(entity);
            await Save();
            return entity;
        }

        public async Task<T> Find(Expression<Func<T, bool>> express )
        {
            return await EntitySet.AsNoTracking().FirstOrDefaultAsync(express);
        }
        
        public virtual IQueryable<T> Query(Expression<Func<T, bool>> where)
        {
            IQueryable<T> query = EntitySet;

            if (where != null)
            {
                query = query.Where(where);
            }

            return query;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (! this.disposed)
            {
                if (disposing)
                {
                    contex.Dispose();
                }
            }
            this.disposed = true;
        } 

        public void Dispose()
        {
            Dispose(true);
        }
    }
}