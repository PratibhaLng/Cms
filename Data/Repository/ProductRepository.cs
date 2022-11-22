using Data.Models;
using Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            var objfromDb = _db.Product.FirstOrDefault(x => x.Id == obj.Id);
            if (objfromDb != null)
            {
                objfromDb.Name = obj.Name;
                objfromDb.Description = obj.Description;
                objfromDb.Price = obj.Price;
                objfromDb.UpdatedDate = DateTime.Now;
            }
        }
    
    }
}
