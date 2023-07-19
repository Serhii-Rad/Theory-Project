using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Connection
{
    internal class Client
    {
        public static void Start(string message, string serverIp = "127.0.0.1", int port = 23)
        {
            try
            {
                // Create a TCP client object and connect to the server
                TcpClient client = new TcpClient(serverIp, port);
                Console.WriteLine("Connected to server: {0}:{1}", serverIp, port);

                // Get the network stream for reading and writing
                NetworkStream stream = client.GetStream();

                // Send data to the server
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Data sent to server: {0}", message);

                // Read the response from the server
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Response received from server: {0}", response);

                // Close the connection
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: {0}", ex.Message);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
