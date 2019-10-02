using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using Newtonsoft.Json;

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
                bool isRunning = true;
                while (isRunning)
                {
                    string str = sr.ReadLine();
                    string str2;
                    string returnstr = null;
                    switch (str.ToLower())
                    {
                        case "hentalle":
                            returnstr = JsonConvert.SerializeObject(BogList);
                            break;
                        case "hent":
                            str2 = sr.ReadLine();
                            Bog bog = BogList.Find(b => b.Isbn == str2);
                            returnstr = JsonConvert.SerializeObject(bog);
                            break;
                        case "gem":
                            str2 = sr.ReadLine();
                            Bog bog1 = JsonConvert.DeserializeObject<Bog>(str2);
                            BogList.Add(bog1);
                            break;
                        case "stop":
                            isRunning = false;
                            break;
                    }
                    sw.WriteLine(returnstr);
                    sw.Flush();
                }
            }
        }


    }
}
