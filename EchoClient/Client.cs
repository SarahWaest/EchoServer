using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace EchoClient
{
    public class Client
    {
        private TcpClient _tcpClient;
        private const int _port = 7;
        private TcpClient connectionSocket;

        public Client()
        {
            _tcpClient = new TcpClient("192.168.24.245", _port);
        }


        public void Start()
        {
            using (connectionSocket = _tcpClient)
            {
                Stream ns = connectionSocket.GetStream();
                Console.WriteLine("Server activated");

                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;
                
                string message = sr.ReadLine();
                string answer = "hej";
                while (message != null && message != "")
                {
                    Console.WriteLine("Client:" + message);
                    answer = message.ToUpper();
                    sw.WriteLine(answer);
                    message = sr.ReadLine();
                }
                //ns.Close();
                //connectionSocket.Close();
            }
        }
    }
}