using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Connection
{
    internal class Server
    {
        public static void Start(string responseMessage, string serverIp = "127.0.0.1", int port = 23)
        {
            // Create a TCP listener object
            TcpListener listener = new TcpListener(IPAddress.Parse(serverIp), port);

            try
            {
                // Start listening for incoming connections
                listener.Start();
                Console.WriteLine("Server is listening on {0}:{1}", serverIp, port);

                // Accept the client connection
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client connected: {0}", client.Client.RemoteEndPoint);

                // Get the network stream for reading and writing
                NetworkStream stream = client.GetStream();

                // Read data from the client
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Data received from client: {0}", dataReceived);

                // Send a response to the client
                byte[] responseData = Encoding.ASCII.GetBytes(responseMessage);
                stream.Write(responseData, 0, responseData.Length);
                Console.WriteLine("Response sent to client: {0}", responseMessage);

                // Close the connection
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: {0}", ex.Message);
            }
            finally
            {
                // Stop listening for connections
                listener.Stop();
            }

            Console.WriteLine("Server has stopped listening. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
