using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using ToDoLib;

namespace ToDoGUI.ViewModel
{
    class ComparisonComparer<T> : IComparer<T>
    {
        Comparison<T> _comparer;

        public ComparisonComparer(Comparison<T> comparer)
        {
            _comparer = comparer;
        }

        public int Compare(T x, T y)
        {
            return _comparer(x, y);
        }
    }

    public class ToDoListView : INotifyCollectionChanged, IEnumerable<TaskView>
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged = delegate { };

        ItemListClient _client;
        List<TaskView> _tasks;

        public ToDoListView(ItemListClient client)
        {
            _client = client;
            _tasks = _client.GetAllTasks().OrderBy(itm => itm.DeadLine).Select(itm => new TaskView(itm)).ToList();
        }

        public void Add(Item task)
        {
            _client.Add(task);

            var model = new TaskView(task);
            var index = _tasks.BinarySearch(model, new ComparisonComparer<TaskView>((a, b) => a.Item.DeadLine.CompareTo(b.Item.DeadLine)));
            if (index < 0) index = ~index;
            _tasks.Insert(index, model);
            
            this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, model, index));
        }

        #region IEnumerator<TaskView>

        public IEnumerator<TaskView> GetEnumerator()
        {
            return _tasks.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }

    public class TaskView
    {
        Item _item;

        public Item Item { get { return _item; } }
        
        public TaskView(Item item)
        {
            _item = item;
        }
    }
}
