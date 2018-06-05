using SerializableFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Client : IDisposable
    {
        private TcpClient client;

        public Client(String host, int port)
        {
            client = new TcpClient();
            client.Connect(host, port);
        }

        public void Dispose()
        {
            this.client.Close();
        }

        public void SendData(SerializableFile.SerializableFile serializableFile)
        {
            Serialize.writeToStream(client.GetStream(), serializableFile);
        }

    }
}
