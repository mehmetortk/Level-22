﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {

        public void Add(Product entity)
        {/*northwind context fazla yer kapladıgı için using
          * kullanarak new lersek işimiz bitince çöp kutusuna gider
          * bu durumda fazla yer kaplamadan işlem yapar.
          *Sonrasında Entry ile referans yakalanır. State durum ile
          * ekleme uygulanır ve değişikler kaydolur.*/

            using NorthwindContext context = new NorthwindContext();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(Product entity)
        {
            using NorthwindContext context = new NorthwindContext();
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context= new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault
                    (filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                if (filter == null)
                {
                    return context.Set<Product>().ToList();
                }
                else
                {
                    return context.Set<Product>().Where(filter).ToList();
                }
            }
        }

        public void Update(Product entity)
        {
            using NorthwindContext context = new NorthwindContext();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}