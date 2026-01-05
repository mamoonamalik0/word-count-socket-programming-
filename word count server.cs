using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        TcpClient client = new TcpClient("127.0.0.1", 5001);
        NetworkStream stream = client.GetStream();
        Console.Write("Enter a sentence: ");
        string sentence = Console.ReadLine();
        byte[] data = Encoding.ASCII.GetBytes(sentence);
        stream.Write(data, 0, data.Length);
        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string result = Encoding.ASCII.GetString(buffer, 0, bytesRead);
        Console.WriteLine("Number of words: " + result);
        client.Close();
    }
}

