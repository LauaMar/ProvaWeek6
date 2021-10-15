using ProvaWeek6.Core.Entity;
using ProvaWeek6.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProvaWeek6.Core.EF.EFRepository
{
    public class EFClientRepository : IClientRepository
    {
        private ManagerContext ctx;
        public EFClientRepository()
        {
            this.ctx = new ManagerContext();
        }
        public EFClientRepository(ManagerContext context)
        {
            this.ctx = context;
        }
        public bool Add(Client newItem)
        {
            if (newItem == null)
                return false;
            try
            {
                ctx.Clients.Add(newItem);
                ctx.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false; 
            }
        }

        public bool DeleteById(int id)
        {
            if (id<=0)
                return false;
            try
            {
                Client toBeRemoved = ctx.Clients.Find(id);
                if (toBeRemoved == null)
                    return false;
                ctx.Clients.Remove(toBeRemoved);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Client editedItem)
        {
            if (editedItem.Id <= 0)
                return false;
            try
            {
                Client toBeModified = ctx.Clients.Find(editedItem.Id);
                if (toBeModified == null)
                    return false;
                toBeModified.ClientCode = editedItem.ClientCode;
                toBeModified.FirstName = editedItem.FirstName;
                toBeModified.LastName = editedItem.LastName;
                ctx.SaveChanges();
                return true;
            }
            catch(Exception)
            { 
                return false; 
            }
        }

        public IEnumerable<Client> Fetch(Func<Client, bool> filter = null)
        {
            try
            {
                if (filter != null)
                    return ctx.Clients.Where(filter);

                return ctx.Clients;
            }
            catch(Exception)
            { 
                return new List<Client>();
            }
        }

        public Client GetById(int id)
        {
            if (id == 0)
                return null;

            return ctx.Clients.Find(id);
        }

        public Client FetchByClientCode(string clientCode)
        {
            if (string.IsNullOrEmpty(clientCode))
                return null;

            return ctx.Clients.SingleOrDefault(c => c.ClientCode == clientCode);
        }
    }
}
