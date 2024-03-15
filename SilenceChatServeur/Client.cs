using SilenceChatServeur.Net.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SilenceChatServeur
{
    class Client
    {
        /* récip du nom, de uid et du client*/
        public string Username { get; set; }
        public Guid UID { get; set; }
        public TcpClient ClientSocket { get; set; }

        PacketReader _packetReader;

        public Client(TcpClient client) 
        {

            ClientSocket = client;
            UID = Guid.NewGuid();
            _packetReader = new PacketReader(ClientSocket.GetStream());

            var opcode = _packetReader.ReadByte();
            Username = _packetReader.ReadMessage();

            /* création des logs de connection*/
            Console.WriteLine($"[{DateTime.Now}] : Client has Connected with the username : {Username}");
            Task.Run(() => Process());
            
        }

        void Process()
        {
            while (true)
            {
                try
                {
                    var opcode = _packetReader.ReadByte();
                    switch (opcode)
                    {
                        case 5:
                            var msg = _packetReader.ReadMessage();
                            Console.WriteLine($"[{DateTime.Now}] {Username} : as envoyer  {msg}");
                            Program.BroadcastMessage($"[{DateTime.Now}] {Username} : {msg}");
                            break;
                        default:
                            break;

                    }


                }
                catch
                {
                    Console.WriteLine($"[{UID.ToString()}] [{Username}]: est deconnecter");
                    Program.BroadcastDisconnectMessage(UID.ToString());
                    ClientSocket.Close();
                    break;
                }
            }
        }

    }

        
    
}

