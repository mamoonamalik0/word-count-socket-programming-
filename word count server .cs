using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void Main()
    {
        TcpListener server = new TcpListener(IPAddress.Any, 5001);
        server.Start();
        Console.WriteLine("Server started... Waiting for client");

        TcpClient client = server.AcceptTcpClient();
        NetworkStream stream = client.GetStream();

        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string sentence = Encoding.ASCII.GetString(buffer, 0, bytesRead);

        string[] words = sentence.Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
        int wordCount = words.Length;

        byte[] sendData = Encoding.ASCII.GetBytes(wordCount.ToString());
        stream.Write(sendData, 0, sendData.Length);

        Console.WriteLine("Word count sent to client");

        client.Close();
        server.Stop();
    }
}
