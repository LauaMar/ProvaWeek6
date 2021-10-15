using ProvaWeek6.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaWeek6.Core.Interfaces
{
   public interface IManagerBL
    {
        #region Client
        List<Client> FetchClients(Func<Client, bool> filter = null);
        Client FetchClientById(int id);
        bool CreateClient(Client newClient);
        bool EditClient(Client editedClient);
        bool DeleteClientById(int id);
        #endregion

        #region Order
        List<Order> FetchOrders(Func<Order, bool> filter = null);
        Order FetchOrderById(int id);
        bool CreateOrder(Order newOrder);
        bool EditOrder(Order editedOrder);
        bool DeleteOrderById(int id);
        #endregion

        #region Reports
        List<Order> FetchOrderByClientCode(string clientCode);
        Order FetchCompleteOrder(int orderId);

        #endregion
    }
}
