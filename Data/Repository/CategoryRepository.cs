using Data.Models;
using Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            var objfromDb = _db.Category.FirstOrDefault(x => x.Id == obj.Id);
            if (objfromDb != null)
            {
                objfromDb.Name = obj.Name;
                objfromDb.UpdatedDate = DateTime.Now;
                objfromDb.UpdatedBy = "user";
            }
        }
    }
}
