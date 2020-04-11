using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AssignmenApp.API.Data
{
    public class AssignmentRepository<TEntity> : IAssignmentRepository<TEntity> where TEntity : class
    {

     private readonly DataContext _context;
     private readonly DbSet<TEntity> _dbSet;
     
        public AssignmentRepository(DataContext context)
        {
            _context = context;
            var dbContext = _context as DbContext;

            if (dbContext != null)
            {
                _dbSet = dbContext.Set<TEntity>();
            }

        }
    
        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();

         public IQueryable<TEntity> Queryable()
        {
            return _dbSet;
        }
        
        public async Task<EntityEntry> InsertAsync(TEntity entity)
        {
            
            return await _dbSet.AddAsync(entity);
        }
    
        public async Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
           
            await _dbSet.AddRangeAsync(entities);
        }
        
        public  bool Update(TEntity entity)
        {
            
            _dbSet.Attach(entity);
            return true;
        }
        
       public  bool Remove(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
            return true;
        }
        public  void RemoveRange(IEnumerable<TEntity> entities) => _dbSet.RemoveRange(entities);
       
        
    }
}