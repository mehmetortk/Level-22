using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryProductDal:IProductDal
   {
       public List<Product> _products;

       public InMemoryProductDal()
       {
           _products = new List<Product>
           {
               new Product{CategoryId = 1, ProductId = 1, ProductName = "Apple", UnitPrice = 20, UnitsInStock = 15},
               new Product{CategoryId = 1, ProductId = 2, ProductName = "Melon", UnitPrice = 22, UnitsInStock = 15},
               new Product{CategoryId = 1, ProductId = 3, ProductName = "Peach", UnitPrice = 10, UnitsInStock = 35},
               new Product{CategoryId = 2, ProductId = 4, ProductName = "Tomato", UnitPrice = 7, UnitsInStock = 25},
               new Product{CategoryId = 2, ProductId = 5, ProductName = "Broccoli", UnitPrice = 14, UnitsInStock = 65}

           };
       }

        public void Add(Product product)
        {
           _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product DeleteToProduct;
            /*Burada SingleOrDefault kodu ile linQ kullandık sebebi ise biz burada delete işlemini yaptırmak istediğimizde
             referanslar farklı oldugundan ve onları döndüren bir şey olmadıgından sorun cıkacaktı bunu engellemek için
            uzun yöntem ile foreach kullanıp referans döndürebileceğimiz gibi linQ ile SingleOrDefault'u kullanarakta
            referansların döngü ile dönmesini sağlarız parametlere kısmına en başta tıpkı döngüdeki gibi takma ad verilir
            burada p dendi ardında => mantıktaki ise işareti kullanılıp şart öne sürülür. SingleOrDefault yerine
            First ve FirstOrDefault da yazılabilir.*/
            DeleteToProduct = _products.SingleOrDefault(p=> p.ProductId==product.ProductId);
            _products.Remove(DeleteToProduct);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
          return  _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product UpdateToProduct;
            UpdateToProduct = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            UpdateToProduct.ProductName = product.ProductName;
        }
    }
}
