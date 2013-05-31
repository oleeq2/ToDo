using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ServiceModel;
using ToDoLib;

namespace ToDoGUI
{
    public class ItemListClient
    {

        IItemList channel;

        public ItemListClient()
        {
            ChannelFactory<IItemList> _factory = new ChannelFactory<IItemList>("CliEndPoint");
            channel = _factory.CreateChannel();
        }

        public ItemListClient(string uri)
        {
            ChannelFactory<IItemList> _factory = new ChannelFactory<IItemList>("CliEndPoint", new EndpointAddress(uri));
            channel = _factory.CreateChannel();
        }

        public void Add(Item task)
        {
            channel.Add(task);
        }

        public IEnumerable<Item> GetAllTasks()
        {
            return channel.Find(FilterType.All, "");
        }
    }
}
