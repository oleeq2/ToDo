using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ToDoLib
{
   public abstract class Package
   {
       public virtual void SendPackage(Socket sck)
       {
           throw new NotImplementedException();
       }
       public static virtual Package ReceivePackage(Socket sck)
       {
           throw new NotImplementedException();
       }
       abstract byte[] ToArray();
   }

   [DataContract]
   public class Request : Package
   {
       [DataMember]
       public ItemList data     { public get; set; }
       [DataMember]
       public ItemAction action { public get; set; }
       [DataMember]
       public FilterType filter { public get; set; }
       [DataMember]
       public string filter_key { public get; set; }

       static DataContractJsonSerializer _serializer = new DataContractJsonSerializer(typeof(Request));

       public Request(ItemAction action, ItemList data)
       {
           this.action     = action;
           this.data       = data;
           this.filter     = 0;
           this.filter_key = string.Empty;
       }
       public Request(ItemAction action,FilterType type,string filter_key)
       {
           this.action     = action;
           this.data       = null;
           this.filter     = type;
           this.filter_key = filter_key;
       }

       byte[] ToByte()
       {
           MemoryStream ms = new MemoryStream();
           _serializer.WriteObject(ms, this);
           return ms.ToArray();
       }

       public override void SendPackage(Socket sck)
       {
           throw new NotImplementedException();
       }

       public static override Request ReceivePackage(Socket sck)
       {
           throw new NotImplementedException();
       }
   }

   [DataContract]
   public class Response: Package
   {
       [DataMember]
       public Status status  { public get; set; }
       [DataMember]
       public ItemList data  { public get; set; }
       [DataMember]
       public string Message { public get; set; }

       static DataContractJsonSerializer _serializer = new DataContractJsonSerializer(typeof(Response));

       public Response(Status status,string Message)
       {
           this.status = status;
           this.Message = Message;
           this.data = null;
       }

       public Response(Status status, ItemList data,string msg)
       {
           this.status = status;
           this.data = data;
           this.Message = msg;
       }

       byte[] ToByte()
       {
           MemoryStream ms = new MemoryStream();
           _serializer.WriteObject(ms, this);
           return ms.ToArray();
       }

       public override void SendPackage(Socket sck)
       {
           throw new NotImplementedException();
       }

       public static override Response ReceivePackage(Socket sck)
       {
           throw new NotImplementedException();
       }
   }
}
