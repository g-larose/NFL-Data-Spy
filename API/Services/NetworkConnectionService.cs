using API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class NetworkConnectionService : INetworkConnection
    {
        public bool IsConnected()
        {
            var ping = new Ping();
            Uri uri = new Uri("https://www.google.com");
            PingReply reply = ping.Send(uri.Host);
            if (reply.Status == IPStatus.Success)
                return true;

            return false;
            
        }
    }
}
