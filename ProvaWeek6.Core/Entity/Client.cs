using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ProvaWeek6.Core.Entity
{
    [DataContract]
    public class Client
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String ClientCode { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }

        public IList<Order> Orders { get; set; }

    }
}
