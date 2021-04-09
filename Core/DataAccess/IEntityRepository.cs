using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//core katmanı diğer katmanları referans almaz diğer katmanlara bağımlı değildir evrensel ve bağımsızdır.
//core katmanı sayesinde repositoryler diğer databaselerde ve katmanlarda da kullanılabilir
namespace Core.DataAccess
{

/*reason why we use (where T:class) is we don't want any type of thing can be used with T, we only want the ones with references
but in this case we can use anything with references with T hence we added IEntity there which means only the ones that are
implemented by IEntity or IEntity itself can be used with T, but since IEntity here is a abstract class that is interface we
don't want it to be used with T  therefore we add new() there to only use the ones that are implemented by IEntity reason why we use it
because interfaces are not able to be new() that's why.*/
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        //Expression<Func<T,bool>> filter bu yapı ile List<T> GetAllByCategory(int categoryId); gibi bir kullanıma ihtiyaç kalmıyor.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
