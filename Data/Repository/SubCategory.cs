using Data.Models;
using Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        private ApplicationDbContext _db;

        public SubCategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SubCategory obj)
        {
            var objfromDb =_db.SubCategory.FirstOrDefault(x => x.Id == obj.Id);
            if (objfromDb != null)
            {   
                objfromDb.Name = obj.Name;
            objfromDb.UpdatedDate = DateTime.Now;
            }
        }
    }
}
