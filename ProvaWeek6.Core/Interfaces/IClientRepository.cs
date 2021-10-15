using ProvaWeek6.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaWeek6.Core.Interfaces
{
    public interface IClientRepository :IRepository<Client>
    {
        Client FetchByClientCode(string clientCode);
    }
}
