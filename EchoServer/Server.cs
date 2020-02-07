using System;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace EchoServer
{
    class Server
    {
        private TcpListener _tcpListener;
        private const int _port = 7;
        private IPAddress _ipAddress;
        private TcpClient connectionSocket;
        public Server()
        {
            _ipAddress = IPAddress.Loopback;
            _tcpListener = new TcpListener(_ipAddress, _port);
        }

        public void Start()
        {
            _tcpListener.Start();
            using (connectionSocket = _tcpListener.AcceptTcpClient())
            {
                DoClient(connectionSocket);
            }
        }

        public void DoClient(TcpClient socket)
        {
                Stream ns = connectionSocket.GetStream();
                Console.WriteLine("Server activated");

                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;

                string message = sr.ReadLine();
                string answer;
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