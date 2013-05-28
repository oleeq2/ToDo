using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoGUI.ItemListProxy;
using ToDoLib;

namespace ToDoGUI
{
    class ItemListWrapper: IEnumerable<Item>
    {
        ItemListClient cli;
        public ItemListWrapper()
        {
            cli = new ItemListClient();
        }
        //TODO Address 

        public void Add(Item itm)
        {
            cli.Add(itm);
        }

        public ItemList Find(FilterType type, string str)
        {
            return cli.Find(type, str);
        }

        public void mergeWith(ItemList _lst)
        {
            cli.mergeWith((Object)_lst);
        }

        public IEnumerator<Item> GetEnumerator()
        {
            ItemList obj = cli.Find(FilterType.All, "");
            return obj.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
