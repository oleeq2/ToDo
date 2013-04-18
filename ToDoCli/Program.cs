using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoLib;
using System.ServiceModel;
using ToDoCli.ToDoItemProxy;

namespace ToDoCli
{
    class Program
    {
        public static void Main(string []args)
        {

            CSVPresent csvnb = new CSVPresent();
            ConsoleMenu menu = new ConsoleMenu();
            ItemListClient nb = new ItemListClient();
            MenuSelect state;
            do
            {
                state = menu.generalMenu();
                switch (state)
                {
                    case MenuSelect.CreateMenu:
                    {
                        try
                        {
                            nb.Add(menu.getItem());
                        }
                        catch(System.FormatException)
                        {
                            Console.WriteLine("Format error\n"+
                                              "Item not added");
                        }
                            break;
                    }

                    case MenuSelect.SearchMenu:
                    {
                            FilterType searchT;
                            string match = menu.searchMenu(out searchT);
                            ItemList res = nb.Find(searchT, match);
                                
                            foreach (Item itm in res)
                                Console.WriteLine(itm.ToString() + "\n");
                            break;
                    }
                    case MenuSelect.FileOperationMenu:
                    {
                        FileOperation operation;
                        string path;
                        bool flag = menu.FileOperationMenu(out operation,out path);
                        if (!flag)
                        {
                            continue;
                        }
                        switch (operation)
                        {
                            case FileOperation.Read:
                            {
                                try
                                {
                                    csvnb.ReadFromFile(path);
                                    nb.mergeWith(csvnb.CSVToProg());
                                }
                                catch (System.IO.IOException)
                                {
                                    Console.WriteLine("IO error, data doesn't load");
                                }
                                catch (System.FormatException)
                                {
                                    Console.WriteLine("File format error");
                                }
                                    break;
                            }
                            case FileOperation.Write:
                            {
                                try
                                {
                                //    csvnb.ProgToCSV((nb);
                                 //   csvnb.SaveToFile(path);
                                }
                                catch (System.IO.IOException)
                                {
                                    Console.WriteLine("IO Error, data doesn't save");
                                }
                                    break;
                            }
                        }
                        break;
                    }
                    case MenuSelect.Exit:
                    {
                   //     nb.Disconnect();
                        break;
                    }
                    default:
                    {
                            Console.WriteLine("No such command!");
                            break;
                    } 
                }
            } while (state != MenuSelect.Exit);
        }
    }
}
