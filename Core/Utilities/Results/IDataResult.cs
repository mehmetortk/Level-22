using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
   public interface IDataResult<T>:IResult
    {//bu interface'in sebebi error veya success döndürmesi fakat halihazırda bu işi IResult gördüğü için onu
     //buraya implemente ediyoruz farkı ise IResult data tutamazken IDataResult tutabilecek şekilde tasarlanır.
        T Data { get; }
    }
}
