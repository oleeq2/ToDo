using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using ToDoLib;

namespace ToDoCli
{
    enum FileOperation
    {
        Read  = 0,
        Write = 1 
    }

    enum MenuSelect
    {
        CreateMenu        = 1,
        SearchMenu        = 2,
        FileOperationMenu = 3, 
        Exit              = 4
    }

    class ConsoleMenu
    {
        public Item getItem()
        {
            Console.Write("\nTitle: ");
            string title = Console.ReadLine();

            Console.Write("Description: ");
            string desc = Console.ReadLine();

            Console.Write("Deadline:");
            DateTime deadline = DateTime.Parse(Console.ReadLine());
            int count=1;
            string curr_tag;
            List<string> tags = new List<string>();
            do
            {
                Console.Write(count+": ");
                curr_tag = Console.ReadLine();
                tags.Add(curr_tag);
                count++;
            } while (!string.IsNullOrEmpty(curr_tag));
            
            return new Item(title,desc,deadline,tags);
        }

        public  string searchMenu(out FilterType type)
        {
            Console.Write("Select a type of search:" +
                "\n\t1.Search by title" +
                "\n\t2.Search by description" +
                "\n\t3.Search by tag" +
                "\n\t4.Get last tasks"+
                "\n>");
            if(!Enum.TryParse(Console.ReadLine(), out type))
                throw new ApplicationException();
            Console.Write("Enter find key: ");
            return Console.ReadLine();
        }

        private  string _getPath()
        {
            Console.Write("Enter directory path[Press enter for default]:\n ");
            string dir = Console.ReadLine();
            if (dir.Equals(""))
            {
                dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            Console.Write("Enter filename:\n ");
            string file = Console.ReadLine();
            return Path.Combine(dir, file);
        }

        private  bool _askUser(string msg)
        {
            bool ret = false;
            Console.Write(msg+"[Y/N]");
           
            bool flag = false;
            do{
                string answer = Console.ReadLine();
                flag = false;
                if(answer.ToUpper().Equals("Y"))
                    ret = true;
                else if(answer.ToUpper().Equals("N"))
                    ret = false;
                else
                {
                    Console.WriteLine("Unexpected input, please enter again: ");
                    flag = true;
                }
            }while(flag);
            return ret;
        }

        public  bool getPathMenu(FileOperation rw,out string path)
        {
            bool ret = true;
            bool flag = false;
            path = String.Empty;
            do
            {
                string str = _getPath();
                if (rw == FileOperation.Write)
                {
                    if (File.Exists(str))
                    {
                        bool ans = _askUser("File exists override? ");
                        if (!ans)
                        {
                            flag = true;
                            continue;
                        }
                        else
                        {
                            path = str;
                        }
                    }
                    path = str;
                }
                path = str;
            }while(flag);

            return ret;
        }

        public bool FileOperationMenu(out FileOperation state,out string path)
        {
            bool ret;
            Console.Write("1. Load from file \n" +
                          "2. Save to file   \n" + 
                          "> ");
            
            if (!FileOperation.TryParse(Console.ReadLine(), out state))
            {
                ret = false;
                path = string.Empty;
            }
            else
            {
                string tmp_path;
                ret = getPathMenu(state,out tmp_path);
                path = tmp_path;
            }
            return ret;
        }

        public MenuSelect generalMenu()
        {
            Console.Write("\t1. Add task\n" +
                          "\t2. Search task\n" +
                          "\t3. Load/Unload from file\n" +
                          "\t4. Exit\n"+
                          "> ");
            MenuSelect ret;
            Enum.TryParse(Console.ReadLine(), out ret);
            return ret;
        } 
    }
}   