using SerwerDzielNa2Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;



namespace SerwerDzielNa2Library
{
    class Program
    {
        static void Main(string[] args)
        {
            SerwerAPM server = new SerwerAPM(IPAddress.Parse("127.0.0.1"), 2048);
            server.Start();
            /*
            while (true)
            {
                TcpClient client = server.AcceptClient();
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                String data = null;
                int i;
                while ((i = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    data = System.Text.Encoding.ASCII.GetString(buffer, 0, i);
                }
                Console.WriteLine("KLIENT");
                double liczba = 0;
                bool czy_liczba = double.TryParse(data, out liczba);
                Console.WriteLine(liczba);
                double wynik = liczba / 2;
                String wiad = wynik.ToString();
                buffer = System.Text.Encoding.ASCII.GetBytes(wiad);
                stream.Write(buffer, 0, buffer.Length);
                Console.WriteLine(wynik);

            }*/
        }
    }
}
