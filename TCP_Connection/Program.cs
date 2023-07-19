using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TCP_Connection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string internalIpAddress = GetInternalIpAddress(); // 192.168.243.8
            //string externalIpAddress = GetExternalIpAddress(); // 186.127.227.102

            //Client.Start("Message from client to server", "192.168.1.132", 5205);
            Server.Start("Message from server to client", "192.168.243.8");
        }

        static string GetInternalIpAddress()
        {
            // Get the local IP address
            string ipAddress = string.Empty;
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddress = ip.ToString();
                    break;
                }
            }
            return ipAddress;
        }

        static string GetExternalIpAddress()
        {
            try
            {
                // Use a web service to get the external IP address
                WebClient webClient = new WebClient();
                string ipAddress = webClient.DownloadString("https://api.ipify.org");
                return ipAddress;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while getting the external IP address: {0}", ex.Message);
                return string.Empty;
            }
        }
    }
}
