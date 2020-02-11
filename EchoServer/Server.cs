using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading.Tasks;
using EchoClient;

namespace EchoServer
{
    class Server
    {
        private TcpListener _tcpListener;
        private const int _port = 9997;
        //private IPAddress _ipAddress;
        private TcpClient connectionSocket;
        private IPAddress _ipAddress = IPAddress.Parse("192.168.24.187");

        public Server()
        {
            //_ipAddress = IPAddress.Loopback;
            _tcpListener = new TcpListener(_ipAddress, _port);
            Console.WriteLine("Server activated");
        }

        public void Start()
        {
            _tcpListener.Start();

            while (true)
            {
                connectionSocket = _tcpListener.AcceptTcpClient();

                    Task.Run(() =>
                    {
                        TcpClient tempSocket = connectionSocket;
                        DoClient(tempSocket);
                    });

                    //Stream ns = connectionSocket.GetStream();
                    //DoClient(connectionSocket);
            }
        }

        public void DoClient(TcpClient socket)
        {
            Stream ns = connectionSocket.GetStream();
            Console.WriteLine("Client Connected");

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