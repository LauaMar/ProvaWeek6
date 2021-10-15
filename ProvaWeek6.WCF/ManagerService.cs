using AcademyG.Biblioteca.Core;
using ProvaWeek6.Core;
using ProvaWeek6.Core.EF.EFRepository;
using ProvaWeek6.Core.Entity;
using ProvaWeek6.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProvaWeek6.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ManagerService : IManagerService
    {
        IManagerBL managerBL;

        public ManagerService()
        {
            // Configurazione DI
            DependencyContainer.Register<IManagerBL, ManagerBL>();
            DependencyContainer.Register<IClientRepository, EFClientRepository>();
            DependencyContainer.Register<IOrderRepository, EFOrderRepository>();

            // Risoluzione
            this.managerBL = DependencyContainer.Resolve<IManagerBL>();
        }

        public bool AddNewClient(Client newClient)
        {
            if (newClient == null)
                return false;

            return this.managerBL.CreateClient(newClient);

        }

        public bool DeleteClientById(int id)
        {
            return this.managerBL.DeleteClientById(id);
        }

        public bool EditClient(Client editedClient)
        {
            if (editedClient.Id == 0)
                return false;
            return this.managerBL.EditClient(editedClient);
        }

        public IEnumerable<Client> FetchClients()
        {
            return this.managerBL.FetchClients();
        }

        public Order FetchDetailedOrderPerId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> FetchOrdersPerClient(string clientCode)
        {
            return this.managerBL.FetchOrderByClientCode(clientCode);
        }

    }
}
