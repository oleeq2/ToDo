using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace ToDoSrv
{
    class ClientSession
    {
        Socket _sck;

        public ClientSession(Socket sck)
        {
            _sck = sck;
        }

        public void Start()
        {

        }
    }
}
