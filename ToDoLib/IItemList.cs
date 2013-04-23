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
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void Add(Item itm);
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ItemList Find(FilterType type, string key);
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        System.Collections.Generic.IEnumerator<Item> GetEnumerator();
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void mergeWith(IItemList _lst);
        [OperationContract]
        List<Item> ToList();
    }
}
