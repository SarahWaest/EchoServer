using System;

namespace EchoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client clientObject = new Client();
            clientObject.Start();
        }
    }
}
