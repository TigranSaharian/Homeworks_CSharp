using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Time_Server
{
    class Program
    {
        private List<Socket> _ClientSocket = new List<Socket>();
        private Socket _ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main(string[] args)
        {
        }

        private void SetupServer()
        {
            Console.WriteLine("Setting up server...");
            _ServerSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
            _ServerSocket.Listen(5);
            _ServerSocket.BeginAccept(new AsyncCallback(AcceptCallBack), null);
        }

        private static void AcceptCallBack(IAsyncResult ar)
        {

        }
    }
}
