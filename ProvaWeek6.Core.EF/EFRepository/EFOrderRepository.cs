using Microsoft.EntityFrameworkCore;
using ProvaWeek6.Core.Entity;
using ProvaWeek6.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProvaWeek6.Core.EF.EFRepository
{
   public class EFOrderRepository : IOrderRepository
    {
        private ManagerContext ctx;
        public EFOrderRepository()
        {
            this.ctx = new ManagerContext();
        }
        public EFOrderRepository(ManagerContext context)
        {
            this.ctx = context;
        }

        public bool Add(Order newItem)
        {
            if (newItem == null)
                return false;
            try
            {
                ctx.Orders.Add(newItem);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteById(int id)
        {
            if (id <= 0)
                return false;
            try
            {
                Order toBeRemoved = ctx.Orders.Find(id);
                if (toBeRemoved == null)
                    return false;
                ctx.Orders.Remove(toBeRemoved);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Order editedItem)
        {
            if (editedItem.Id <= 0)
                return false;
            try
            {
                Order toBeModified = ctx.Orders.Find(editedItem.Id);
                if (toBeModified == null)
                    return false;
                toBeModified.OrderCode = editedItem.OrderCode;
                toBeModified.OrderDate = editedItem.OrderDate;
                toBeModified.ProductCode = editedItem.ProductCode;
                toBeModified.Amount = editedItem.Amount;
                toBeModified.ClientId = editedItem.ClientId;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Order> Fetch(Func<Order, bool> filter = null)
        {
            try
            {
                if (filter != null)
                    return ctx.Orders.Where(filter);

                return ctx.Orders;
            }
            catch (Exception)
            {
                return new List<Order>();
            }
        }

        public Order GetById(int id)
        {
            if (id == 0)
                return null;

            return ctx.Orders.Find(id);
        }

        public Order FetchCompleteOrderById(int id)
        {            if (id == 0)
                return null;
            Order order=  ctx.Orders.Include(o => o.Client).ToList().Find(o =>o.Id ==id);
            return order;

        }
    }
}
