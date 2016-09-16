using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.TCP
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("127.0.0.1", 0297);
            NetworkStream stream = tcpClient.GetStream();
            string response = "Hello world!";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(response);
            stream.Write(data, 0, data.Length);
            Console.WriteLine("Connected!");
            Console.ReadKey();
        }
    }
}
