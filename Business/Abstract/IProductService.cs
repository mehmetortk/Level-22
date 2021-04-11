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
   {
       List<Product> GetAll();

       List<Product> GetAllByCategory(int id);
        List<ProductDetailDto> GetProductDetails();
        Product GetById(int productId);
        IResult add(Product product);

   }
}
