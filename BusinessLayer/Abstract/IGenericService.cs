using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> TGetAllAsync();
        Task<TEntity> TGetByIdAsync(int id);
        Task TAddAsync(TEntity entity);
        Task TUpdateAsync(TEntity entity);
        Task TDeleteAsync(TEntity entity);
    }
}
