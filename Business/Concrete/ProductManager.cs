using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager:IProductService
    {

         IProductDal _productDal;
         

        public  ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult add(Product product)
        
        {
            if (product.ProductName.Length<2)
            {
                return new ErrorResult("Product name must contain at least 2 characters!!!");
            }
            _productDal.Add(product);
            return new SuccessResult("Product Added!!");
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategory(int id)
        {
            return _productDal.GetAll(p=> p.CategoryId==id);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p=> p.ProductId==productId);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
