using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;

namespace ObligatoriskOpgave5
{
    class Worker
    {
        public static List<Bog> BogList;

        public Worker()
     {
        BogList = new List<Bog>()
            {
            new Bog("Very Poter", "Gertrud", 12, "1234657980123"),
            new Bog("Little Poter", "Gertrud", 13, "1234657980124"),
            new Bog("Big Poter", "Gertrud", 666, "1234657980125"),
            new Bog("Poter", "Gertrud", 12, "1234657980126")
         };
     }
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 4646);
            server.Start();

            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();
                Task.Run(
                    () =>
                    {
                        TcpClient tmpsocket = socket;
                        DoClient(tmpsocket);

                    }
                );
            }
        }

        private static void DoClient(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                while (true)
                {
                    string str = sr.ReadLine();
                    sw.WriteLine(str);
                    sw.Flush();
                }
            }
        }

        private void Get(string isbn)
        {

        }

        private void GetAll(string isbn)
        {

        }

        private void Put()
        {

        }
    }
}
