using SerializableFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Server : IDisposable
    {

        private TcpListener listener;

        public Server(String host, int port)
        {
            this.listener = new TcpListener(IPAddress.Parse(host), port);
            this.listener.Start();
        }

        public void listen()
        {
            while (true)
            {
                Console.WriteLine("Waiting for a client...");

                TcpClient client = listener.AcceptTcpClient();

                new Thread( () => clientThread(client)).Start();

                Console.WriteLine("Connection estabilished!");
            }
        }

        private void clientThread(TcpClient client)
        {
            byte[] bytes = new byte[256];
       
            SerializableFile.SerializableFile serializableFile = SerializableFile.Serialize.readStream(client.GetStream());
            System.IO.File.WriteAllBytes(serializableFile.Filename, serializableFile.File);

            client.Close();
        }

        public void stop()
        {
            listener.Stop();
        }
        public void Dispose()
        {
            this.stop();
        }
    }
}
