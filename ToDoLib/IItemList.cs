using System;
namespace ToDoLib
{
    public interface IItemList
    {
        void Add(Item itm);
        ItemList Find(FilterType type, string key);
        System.Collections.Generic.IEnumerator<Item> GetEnumerator();
        void mergeWith(ItemList _lst);
    }
}
