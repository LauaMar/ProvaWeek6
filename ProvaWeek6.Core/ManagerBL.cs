using AcademyG.Biblioteca.Core;
using ProvaWeek6.Core.Entity;
using ProvaWeek6.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProvaWeek6.Core
{
    public class ManagerBL : IManagerBL
    {
        private readonly IClientRepository clientRepo;
        private readonly IOrderRepository orderRepo;

        public ManagerBL()
        {
            this.clientRepo = DependencyContainer.Resolve<IClientRepository>();
            this.orderRepo = DependencyContainer.Resolve<IOrderRepository>();
        }
        public ManagerBL(IClientRepository clientR, IOrderRepository orderR)
        {
            this.clientRepo = clientR;
            this.orderRepo = orderR;
        }

        #region Client
        public bool CreateClient(Client newClient)
        {
            if (newClient == null)
                return false;
            return this.clientRepo.Add(newClient);
        }

        public bool DeleteClientById(int id)
        {
            if (id <=0 )
                return false;
            return this.clientRepo.DeleteById(id);

        }

        public bool EditClient(Client editedClient)
        {
            if (editedClient == null)
                return false;
            return this.clientRepo.Edit(editedClient);
        }

        public Client FetchClientById(int id)
        {
            if (id <= 0)
                return null;
            return this.clientRepo.GetById(id);
        }

        public List<Client> FetchClients(Func<Client, bool> filter = null)
        {
            return this.clientRepo.Fetch().ToList();
        }
        #endregion

        #region Order
        public bool CreateOrder(Order newOrder)
        {
            if (newOrder == null)
                return false;
            return this.orderRepo.Add(newOrder);
        }

        public bool DeleteOrderById(int id)
        {
            if (id <= 0)
                return false;
            return this.orderRepo.DeleteById(id);

        }

        public bool EditOrder(Order editedOrder)
        {
            if (editedOrder == null)
                return false;
            return this.orderRepo.Edit(editedOrder);
        }

        public Order FetchOrderById(int id)
        {
            if (id <= 0)
                return null;
            return this.orderRepo.GetById(id);
        }

        public List<Order> FetchOrders(Func<Order, bool> filter = null)
        {
            return this.orderRepo.Fetch().ToList();
        }
        #endregion

        #region Reports

        public List<Order> FetchOrderByClientCode(string clientCode)
        {
            if (String.IsNullOrEmpty(clientCode))
                return new List<Order>(); 

            Client cliente = this.clientRepo.FetchByClientCode(clientCode);
            if (cliente == null)
                return new List<Order>();

            List<Order> orders = this.orderRepo.Fetch(o => o.ClientId == cliente.Id).ToList();
            return orders;
        }

        public Order FetchCompleteOrder(int orderId)
        {
            if (orderId == 0)
                return null;

            var order = this.orderRepo.FetchCompleteOrderById(orderId);
            if (order == null)
                return null;
            return order;
        }

        public bool OrderPerYear(int year)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
