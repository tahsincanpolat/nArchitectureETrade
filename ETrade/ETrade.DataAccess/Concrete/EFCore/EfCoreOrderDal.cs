using ETrade.DataAccess.Abstract;
using ETrade.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.DataAccess.Concrete.EFCore
{
    public class EfCoreOrderDal : EfCoreGenericRepository<Order,DataContext>, IOrderDal
    {
    }
}
