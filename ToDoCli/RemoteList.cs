using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

using ToDoLib;

namespace ToDoCli
{
    class RemoteList: IItemList
    {
        Socket _sck;
        public RemoteList(string ip,int port)
        {
            _sck = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            _sck.Connect(ip, port);
        }

        public void Add(Item itm)
        {
            ItemList data = new ItemList();
            data.Add(itm);
            Request request = new Request(ItemAction.Add, data);
            request.SendPackage(_sck);
        }

        public ItemList Find(FilterType type, string key)
        {
            Request request = new Request(ItemAction.Search, type, key);
            request.SendPackage(_sck);
            Response response = (Response)Response.ReceivePackage(_sck);
            return response.data;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            Request request = new Request(ItemAction.Search, FilterType.All, string.Empty);
            request.SendPackage(_sck);
            Response response = (Response)Response.ReceivePackage(_sck);
            return response.data.GetEnumerator();
        }

        public void mergeWith(ItemList _lst)
        {
            Request request = new Request(ItemAction.Add, _lst);
            request.SendPackage(_sck);
        }
        public void Disconnect()
        {
            Request request = new Request(ItemAction.EmptyAction, null);
            request.SendPackage(_sck);
        }
    }
}
