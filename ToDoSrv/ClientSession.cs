using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using ToDoLib;

namespace ToDoSrv
{
    class ClientSession
    {
        Socket _sck;
        ItemList _lst;

        public ClientSession(Socket sck)
        {
            _lst = new ItemList();
            _lst.Add(new Item("Test","Test item for debug",DateTime.Now,new List<string>()));
            _sck = sck;
        }

        public void Start()
        {
            ItemAction action;
            do
            {
                Request request = (Request)Request.ReceivePackage(_sck);
                action = request.action;
                ItemList data = ParseRequest(request);
                Response response;
                if (action == ItemAction.Search)
                    response = new Response(Status.OK, data, "OK");
                else
                    response = new Response(Status.OK, "OK");

                response.SendPackage(_sck);
            }while(action!=ItemAction.EmptyAction);
        }

        ItemList ParseRequest(Request req)
        {
            ItemAction action = req.action;
            ItemList data     = req.data;
            ItemList ret      = null;
            FilterType type   = req.filter;
            string f_key      = req.filter_key;

            switch(action)
            {
                case ItemAction.EmptyAction:
                    break;
                case ItemAction.Add:
                    {
                        _lst.mergeWith(data);
                        break;
                    }
                case ItemAction.Search:
                    {
                        ret = _lst.Find(type, f_key);                        
                        break;
                    }
            }
            return ret;
        }
    }
}
