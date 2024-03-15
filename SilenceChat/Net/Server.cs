using SilenceChatClient.Net.IO;
using System;
using System.Net.Sockets;


namespace SilenceChatClient.Net
{
    internal class Server
    {
        TcpClient _client;
        PacketBuilder _PacketBuilder;
        public PacketReader PacketReader;

        public event Action connectedEvent;
        public event Action msgReceivedEvent;
        public event Action disconnectUserEvent;

        public Server()
        {
            _client = new TcpClient();
        }


        public void ConnectToServer(string username)
        {

            if(!_client.Connected)
            {
                _client.Connect("127.0.0.1",7891);
                PacketReader = new PacketReader(_client.GetStream());

                if(!string.IsNullOrEmpty(username))
                {
                    var connectPacket = new PacketBuilder();
                    connectPacket.WriteOpCode(0);
                    connectPacket.WriteString(username);
                    _client.Client.Send(connectPacket.GetPacketBytes());
                }
                ReadPackets();
                
            }

        }


        public void ReadPackets()
        {
            Task.Run(() =>
            {
                while(true)
                {
                    var opcode = PacketReader.ReadByte();
                    switch(opcode)
                    {
                        case 1:
                            connectedEvent?.Invoke();
                            break;
                        case 5:
                            msgReceivedEvent?.Invoke();
                            break;
                        case 10:
                            disconnectUserEvent?.Invoke();
                            break;
                        default:
                            Console.WriteLine("ah super...");
                            break;
                    }
                }
            });
        }


        public void SendMessageToServer(String message) 
        { 
            var messagePacket = new PacketBuilder();
            messagePacket.WriteOpCode(5);
            messagePacket.WriteString(message);

            _client.Client.Send(messagePacket.GetPacketBytes());

        }

    }
}
