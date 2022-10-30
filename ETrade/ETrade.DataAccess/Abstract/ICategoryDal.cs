using ETrade.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.DataAccess.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
        void DeleteFromCategory(int categoryId,int productId);
        Category GetByIdWithProducts(int id);
    }
}
