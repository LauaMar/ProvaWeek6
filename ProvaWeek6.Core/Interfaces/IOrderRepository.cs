using ProvaWeek6.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaWeek6.Core.Interfaces
{
    public interface IOrderRepository: IRepository<Order>
    {
        Order FetchCompleteOrderById(int id);
    }
}
