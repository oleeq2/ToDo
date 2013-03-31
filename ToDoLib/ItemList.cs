using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ToDoLib
{
    [DataContract]
    public class ItemList: IEnumerable<Item>, ToDoLib.IItemList
    {
        [DataMember]
        List<Item> list;
        CSVPresent _csv;

        public int Count { get { return list.Count; } }
        public ItemList()
        {
            list = new List<Item>();
        }

        public ItemList(List<Item> _lst)
        {
            foreach (Item i in _lst)
                list.Add(i);
        }

        static ItemList()
        {
            comparer = new ItemComparer();
            _empty = new List<Item>();
            _emptyItemList = new ItemList();
        }

        class ItemComparer : IComparer<Item>
        {
            public int Compare(Item x, Item y)
            {
                return x.DeadLine.CompareTo(y.DeadLine);
            }
        }

        static ItemComparer comparer;
        static readonly List<Item> _empty;
        static readonly ItemList _emptyItemList;

        ItemList GetLasts()
        {
            ItemList ret;
            if (list.Count > 0)
                ret = new ItemList(list.FindAll((Item itm) => itm.DeadLine.CompareTo(list[0].DeadLine.AddDays(1)) < 0));

            else
                ret = _emptyItemList;
            return ret;
        }

        public ItemList Find(FilterType type, string key)
        {
            ItemList ret;
            switch (type)
            {
                case FilterType.NameFilter:
                    {
                        ret = new ItemList(list.FindAll((Item itm) => key == itm.Title));
                        Console.WriteLine("Hello");
                        break;
                    }
                case FilterType.TagFilter:
                    {
                        ret = new ItemList(list.FindAll((Item itm) => itm.Tags.Any<string>((string tag) => key == tag)));
                        break;
                    }
                case FilterType.DescriptionFilter:
                    {
                        ret = new ItemList(list.FindAll((Item itm) => itm.Description.Contains(key)));
                        break;
                    }
                case FilterType.LastItemFilter:
                    {
                        ret = this.GetLasts();
                        break;
                    }
                case FilterType.All:
                    {
                        ret = new ItemList(list);
                        break;
                    }
                default:
                    {
                        ret = null;
                        break;
                    }
            }
            return ret;
        }

        public void Add(Item itm)
        { 
            int index = list.BinarySearch(itm, comparer);
            list.Insert(index < 0 ? ~index : index, itm);
          
        }

        public void mergeWith(ItemList _lst)
        {
            foreach (Item itm in _lst)
            {
                this.Add(itm);
            }
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
