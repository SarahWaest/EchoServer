namespace EchoServer
{
    public class Program
    {
        static void Main(string[]args)
        {
            Server serverObject = new Server();
            serverObject.Start();
        }
    }
}