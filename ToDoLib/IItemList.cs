using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.Generic;

namespace ToDoLib
{
    [ServiceContract]
    public interface IItemList
    {
        [OperationContract]
        void Add(Item itm);
        [OperationContract]
        [WebInvoke(BodyStyle=WebMessageBodyStyle.Wrapped,Method="GET")]
        ItemList Find(FilterType type, string key);
        [OperationContract]
        System.Collections.Generic.IEnumerator<Item> GetEnumerator();
        [OperationContract]
        void mergeWith(IItemList _lst);
        [OperationContract]
        List<Item> ToList();
    }
}
