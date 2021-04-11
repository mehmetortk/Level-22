using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {//IData Resulttaki T: List<Product> oldu bu sayede sadece list product yerine işlem sonucu ve mesajıda dönebilir.
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>>  GetAllByCategory(int id);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        IResult add(Product product);

    }
}
