using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoLib;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ToDoSrv
{
    class Program
    {
        static void Main(string[] args)
        {
          
         
            ServiceHost host = new ServiceHost(typeof(ItemList));

            try
            {
                
                host.Open();
                Console.WriteLine("Press <ENTER> to exit");
                Console.ReadLine();
                host.Close();
            }
            catch (TimeoutException Ex)
            {
                Console.WriteLine(Ex);
            }

        }
    }
}
