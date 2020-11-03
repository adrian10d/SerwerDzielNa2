using System;

using System.Collections.Generic;

using System.IO;

using System.Linq;

using System.Net;

using System.Net.Sockets;

using System.Text;


namespace SerwerDzielNa2Library

{

    public class SerwerAPM : SerwerDzielNa2

    {

        public delegate void TransmissionDataDelegate(NetworkStream stream);

        public SerwerAPM(IPAddress IP, int port) : base(IP, port)

        {

        }

        protected override void AcceptClient()

        {

            while (true)

            {

                TcpClient tcpClient = TcpListener.AcceptTcpClient();



                TransmissionDataDelegate transmissionDelegate = new TransmissionDataDelegate(BeginDataTransmission);


                transmissionDelegate.BeginInvoke(Stream, TransmissionCallback, tcpClient);

              

            }

        }


        private void TransmissionCallback(IAsyncResult ar)

        {

            // sprzątanie

        }

        protected override void BeginDataTransmission(NetworkStream stream)

        {

            byte[] buffer = new byte[Buffer_size];

            while (true)

            {

                try

                {

                    int message_size = stream.Read(buffer, 0, Buffer_size);

                    String data = null;
                    int i;
                    data = System.Text.Encoding.ASCII.GetString(buffer, 0, buffer.Length);
                    double liczba = 0;
                    bool czy_liczba = double.TryParse(data, out liczba);
                    double wynik = liczba / 2;
                    String wiad = wynik.ToString();
                    buffer = System.Text.Encoding.ASCII.GetBytes(wiad);


                    stream.Write(buffer, 0, message_size);

                }

                catch (IOException e)

                {

                    break;

                }

            }

        }

        public override void Start()

        {

            StartListening();

            //transmission starts within the accept function

            AcceptClient();

        }


    }

}