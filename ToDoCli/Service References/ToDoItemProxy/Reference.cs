﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.296
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------
using System.ServiceModel.Web;
namespace ToDoCli.ToDoItemProxy {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ToDoItemProxy.IItemList")]
    public interface IItemList {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IItemList/Add", ReplyAction="http://tempuri.org/IItemList/AddResponse")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void Add(ToDoLib.Item itm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IItemList/Find", ReplyAction="http://tempuri.org/IItemList/FindResponse")]
        [WebInvoke(BodyStyle=WebMessageBodyStyle.Wrapped,RequestFormat=WebMessageFormat.Json,ResponseFormat=WebMessageFormat.Json)]
        ToDoLib.ItemList Find(ToDoLib.FilterType type, string key);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IItemList/GetEnumerator", ReplyAction="http://tempuri.org/IItemList/GetEnumeratorResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ToDoLib.Item))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ToDoLib.FilterType))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ToDoLib.ItemList))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ToDoLib.Item[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(string[]))]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        object GetEnumerator();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IItemList/mergeWith", ReplyAction="http://tempuri.org/IItemList/mergeWithResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ToDoLib.Item))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ToDoLib.FilterType))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ToDoLib.ItemList))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ToDoLib.Item[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(string[]))]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void mergeWith(object _lst);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IItemListChannel : ToDoCli.ToDoItemProxy.IItemList, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ItemListClient : System.ServiceModel.ClientBase<ToDoCli.ToDoItemProxy.IItemList>, ToDoCli.ToDoItemProxy.IItemList {
        
        public ItemListClient() {
        }
        
        public ItemListClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ItemListClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ItemListClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ItemListClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Add(ToDoLib.Item itm) {
            base.Channel.Add(itm);
        }
        
        public ToDoLib.ItemList Find(ToDoLib.FilterType type, string key) {
            return base.Channel.Find(type, key);
        }
        
        public object GetEnumerator() {
            return base.Channel.GetEnumerator();
        }
        
        public void mergeWith(object _lst) {
            base.Channel.mergeWith(_lst);
        }
    }
}