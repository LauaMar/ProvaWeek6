using ManagerServiceWCF;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProvaWeek6.ClientService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ManagerServiceClient clientWCF = new ManagerServiceClient();

            HttpClient clientREST = new HttpClient();
            #region main
            int scelta = -1;
            bool uscita = false;
            while (!uscita)
            {
                Console.WriteLine();
                Console.WriteLine("-----------------");
                Console.WriteLine("MENU'");
                Console.WriteLine("-----------------");
                Console.WriteLine("Inserire il codice corrispondente all'azione che si desidera compiere: ");
                Console.WriteLine("[1] --> Inserire nuovo Cliente");
                Console.WriteLine("[2] --> Modificare Cliente");
                Console.WriteLine("[3] --> Cancellare un Cliente");
                Console.WriteLine("[4] --> Visualizzare elenco Clienti");
                Console.WriteLine("[5] --> Inserire nuovo Ordine");
                Console.WriteLine("[6] --> Modificare Ordine");
                Console.WriteLine("[7] --> Cancellare un Ordine");
                Console.WriteLine("[8] --> Visualizzare elenco Ordini");
                Console.WriteLine("[9] --> Visualizzare l'elenco degli Ordini per uno specifico Cliente");
                Console.WriteLine("[10] --> Visualizzare il Dettaglio Ordine per uno specifico Ordine");
                Console.WriteLine("[11] --> Visualizzare Ordini aperti per Anno con numero di ordini e importo totale ordini");
                Console.WriteLine("[0] --> Esci");
                while (!int.TryParse(Console.ReadLine(), out scelta))
                {
                    Console.WriteLine("Codice inserito non corretto, riprova");
                }
                switch (scelta)
                {
                    case 1:
                        Client nuovoCliente = new Client
                        {
                            ClientCode = "CL003",
                            FirstName = "Paolo",
                            LastName = "Bianchi"
                        };
                        bool result = await clientWCF.AddNewClientAsync(nuovoCliente);
                        Console.WriteLine($"Result: {result}");
                        break;
                    case 2:
                        Client daModificare = new Client
                        {
                            Id = 3,
                            ClientCode = "CL003",
                            FirstName = "GianPaolo",
                            LastName = "Bianchini"
                        };
                        result = await clientWCF.EditClientAsync(daModificare);
                        Console.WriteLine($"Result: {result}");
                        break;
                    case 3:
                        int id = 2;
                         result = await clientWCF.DeleteClientByIdAsync(id);
                        Console.WriteLine($"Result: {result}");
                        break;
                    case 4:
                        List<Client> clients = await clientWCF.FetchClientsAsync();

                        foreach (Client cl in clients)
                            Console.WriteLine($"{cl.Id} - {cl.ClientCode} " +
                                $"{cl.LastName.ToUpper()} {cl.FirstName}");
                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
                    case 8:

                        break;
                    case 9:
                        string clientCode = "CL0001";
                        List<Order> ordersPerClient = await clientWCF.FetchOrdersPerClientAsync(clientCode);
                        foreach (Order ord in ordersPerClient)
                            Console.WriteLine($"{ord.Id} {ord.OrderCode} - orderDate: {ord.OrderDate}," +
                                $" ProductCode:{ord.ProductCode}, Amount: {ord.Amount}");
                        break;
                    case 10:

                        break;
                    case 0:
                        uscita = true;
                        break;
                    default:
                        Console.WriteLine("La scelta effettuata non corrisponde a nessuna azione!");
                        Console.WriteLine();
                        break;
                }
            }
            Console.WriteLine("====Alla prossima!====");





            #endregion








            #region Prove

            //List<Client> clients = await clientWCF.FetchClientsAsync();

            //foreach (Client cl in clients)
            //    Console.WriteLine($"{cl.Id} - {cl.ClientCode} " +
            //        $"{cl.LastName.ToUpper()} {cl.FirstName}");

            //bool result = await clientServ.AddNewClientAsync(new Client
            //{
            //    ClientCode="CL003",
            //    FirstName ="Paolo",
            //    LastName= "Bianchi"
            //});
            //Console.WriteLine($"Result: {result}");

            //bool result = await clientServ.EditClientAsync(new Client
            //{
            //    Id = 3,
            //    ClientCode = "CL003",
            //    FirstName = "GianPaolo",
            //    LastName = "Bianchini"
            //});

            //Console.WriteLine($"Result: {result}");

            //bool result = await clientServ.DeleteClientByIdAsync(3);
            //Console.WriteLine($"Result: {result}");
            #endregion



        }
    }
}
