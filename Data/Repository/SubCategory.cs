using Data.Models;
using Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
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
            _db.SubCategory.Include(x => x.Category);
        }

        public void Update(SubCategory obj)
        {
            var objfromDb =_db.SubCategory.FirstOrDefault(x => x.Id == obj.Id);
            if (objfromDb != null)
            {   
                objfromDb.Name = obj.Name;
            objfromDb.UpdatedDate = DateTime.Now;
                objfromDb.UpdatedBy = "user";
               
            }
        }
    }
}
