using ProvaWeek6.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProvaWeek6.WCF
{
    
    [ServiceContract]
    public interface IManagerService
    {

        [OperationContract]
        IEnumerable<Client> FetchClients();

        [OperationContract]
        bool AddNewClient(Client newClient);

        [OperationContract]
        bool EditClient(Client editedClient);

        [OperationContract]
        bool DeleteClientById(int clientId);

        [OperationContract]
        IEnumerable<Order> FetchOrdersPerClient(string clientCode);

        [OperationContract]
        Order FetchDetailedOrderPerId(int id);

    }


}
