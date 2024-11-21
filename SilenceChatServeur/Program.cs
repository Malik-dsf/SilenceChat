using SilenceChatClient.Net.IO;
using System;
using System.Net;
using System.Net.Sockets;


namespace SilenceChatServeur
{

    class Program
    {
        static List<Client> _users;
        static TcpListener _lisener;

        static void Main(string[] args)
        {
            string _address = "127.0.0.1";
            int port = 7891;
            _users = new List<Client>();
            _lisener = new TcpListener(IPAddress.Parse(_address), port);
            _lisener.Start();
            Console.WriteLine("Serveur Lancer!");
            Console.WriteLine($"adresse de connexion : {_address}");
            Console.WriteLine($"port de connexion : {port}");


            while (true)
            {
                var client = new Client(_lisener.AcceptTcpClient());
                _users.Add(client);
                /* il accepte tout le monde sur le serveur*/
                BroadcastConnection();
            }
        }

        static void BroadcastConnection()
        {
            foreach(var user in _users)
            {
                foreach(var usr  in _users)
                {
                    var broadcastPacket = new PacketBuilder();
                    broadcastPacket.WriteOpCode(1);
                    broadcastPacket.WriteMessage(usr.Username);
                    broadcastPacket.WriteMessage(usr.UID.ToString());
                    user.ClientSocket.Client.Send(broadcastPacket.GetPacketBytes());
                }
            }
        }

        public static void BroadcastMessage(string message)
        {
            foreach (var user in _users)
            {
                var msgPacket = new PacketBuilder();
                msgPacket.WriteOpCode(5);
                msgPacket.WriteMessage(message);
                user.ClientSocket.Client.Send(msgPacket.GetPacketBytes());
            }
        }

        public static void BroadcastDisconnectMessage(string uid)
        {
            var disconnectUser = _users.Where(x => x.UID.ToString() == uid).FirstOrDefault();
            _users.Remove(disconnectUser);
            foreach (var user in _users)
            {
                var broadcastPacket = new PacketBuilder();
                broadcastPacket.WriteOpCode(10);
                broadcastPacket.WriteMessage(uid);
                user.ClientSocket.Client.Send(broadcastPacket.GetPacketBytes());
            }

            BroadcastMessage($"[{disconnectUser.Username}] : est deconnecter");
        }
    }


}