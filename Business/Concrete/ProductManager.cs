using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
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
            {//Messages.ProductNameInvalid ile var olan bir mesajı uygun duruma göre kullandık. 
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new DataResult<List<Product>>(_productDal.GetAll(), true, "Products Listed!!");
        }

        public IDataResult<List<Product>> GetAllByCategory(int id)
        {
            return new DataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id), true, "Products Listed!!") ;
        }

        public IDataResult<Product>  GetById(int productId)
        {
            return new DataResult<Product>(_productDal.Get(p => p.ProductId == productId), true, "Products Listed!!");
        }

        public IDataResult<List<ProductDetailDto>>  GetProductDetails()
        {
            return new DataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(), true, "Products Listed!!");
        }
    }
}
