using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ToDoLib
{
    [ServiceContract]
    public interface IItemList
    {
        [OperationContract]
        void Add(Item itm);
        [OperationContract]
        [WebGet(BodyStyle=WebMessageBodyStyle.Wrapped)]
        IItemList Find(FilterType type, string key);
        [OperationContract]
        System.Collections.Generic.IEnumerator<Item> GetEnumerator();
        [OperationContract]
        void mergeWith(IItemList _lst);
    }
}
