using ETrade.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.DataAccess.Abstract
{
    public interface IOrderDal : IRepository<Order>
    {
    }
}
