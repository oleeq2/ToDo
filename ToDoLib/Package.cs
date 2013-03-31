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
    [DataContract]
   public abstract class Package
   {
       public virtual void SendPackage(Socket sck)
       {
           sck.Send(ToByte());
       }

       public static byte[] ReceiveBytes(Socket sck)
       {
           byte[] buff = new byte[512];
           MemoryStream ms = new MemoryStream();
           int counter=0;

           do
           {
               int i = sck.Receive(buff);
               ms.Write(buff, counter, i);
               counter += i;
           }while(buff[counter] != 0);

           return ms.ToArray();
       }

       public abstract byte[] ToByte();

   }

   [DataContract]
   public class Request : Package
   {
       [DataMember]
       public ItemList data     {  get; private set; }
       [DataMember]
       public ItemAction action {  get; private set; }
       [DataMember]
       public FilterType filter {  get; private set; }
       [DataMember]
       public string filter_key {  get; private set; }

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

       public override byte[] ToByte()
       {
           MemoryStream ms = new MemoryStream();
           _serializer.WriteObject(ms, this);
           return ms.ToArray();
       }

       static Request ToPackage(byte[] buffer)
       {
           Request ret;
           ret = (Request)_serializer.ReadObject(new MemoryStream(buffer));
           return ret;
       }

       public static Request ReceivePackage(Socket _sck)
       {
           byte[] buff = Package.ReceiveBytes(_sck);
           return Request.ToPackage(buff);
       }

   }

   [DataContract]
   public class Response: Package
   {
       [DataMember]
       public Status status  {  get; private set; }
       [DataMember]
       public ItemList data  {  get; private set; }
       [DataMember]
       public string Message {  get; private set; }

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

       public override byte[] ToByte()
       {
           MemoryStream ms = new MemoryStream();
           _serializer.WriteObject(ms, this);
           return ms.ToArray();
       }

       static Response ToPackage(byte[] buffer)
       {
           Response ret;
           ret = (Response)_serializer.ReadObject(new MemoryStream(buffer));
           return ret;
       }

       public static Response ReceivePackage(Socket _sck)
       {
           byte[] buff = Package.ReceiveBytes(_sck);
           return Response.ToPackage(buff);
       }
   }
}
