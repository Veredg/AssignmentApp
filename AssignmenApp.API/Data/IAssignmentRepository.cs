using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AssignmenApp.API.Data
{
    public interface IAssignmentRepository<TEntity>  where TEntity : class
    {
          
        Task<int> SaveChangesAsync();
        IQueryable<TEntity> Queryable();
        
        Task<EntityEntry> InsertAsync(TEntity entities);
        Task InsertRangeAsync(IEnumerable<TEntity> entities);
        bool Update(TEntity entity);
 
        bool Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        
       
        
    }

}