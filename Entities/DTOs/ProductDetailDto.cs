using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{// IEntity o classın bir veritabanı tablosu olduguna işaret eder lakin dto'lar bir veritabanı tabloları değildir.
    public class ProductDetailDto : IDto
    {
        public int ProductId { get ; set ; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
