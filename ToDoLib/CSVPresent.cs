using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ToDoLib
{
    public class CSVPresent
    {
         class CSVString : IEnumerable<String>
        {
            List<string> list;
            public CSVString(List<string> lt)
            {
                list = new List<string>(lt);
            }

            public string this[int n]
            {
                get { return list[n]; }
            }

            public override string ToString()// Check this function on debug 
            {
                return String.Join(";", list);
            }

            public IEnumerator<string> GetEnumerator()
            {
                return list.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return (System.Collections.IEnumerator)list.GetEnumerator();
            }
        }

        struct OrderCSV
        {
            public int title { get; set; }
            public int desc { get; set; }
            public int deadline { get; set; }
            public int tags { get; set; }
        }

        String header = "title;desc;deadline;tags";
        List<CSVString> CSVData = new List<CSVString>();

        public void SaveToFile(string path)
        {
            //TODO Error handling
            using (StreamWriter file = new StreamWriter(path, false, Encoding.UTF8))
            {
                file.WriteLine(header);
                //Add write header
                foreach (CSVString i in CSVData)
                {
                    file.WriteLine(i.ToString());
                }
            }
        }

        public void ReadFromFile(string path)
        {
            //TODO Error handling
            using (StreamReader file = new StreamReader(path, Encoding.UTF8))
            {
                string curr;
                while ((curr = file.ReadLine()) != null)
                {
                    CSVData.Add(new CSVString(curr.Split(';').ToList()));
                }
            }
        }

        public ItemList CSVToProg()
        {
            ItemList ret = new ItemList();
            //this	{todo_list.CSVPresent}	todo_list.CSVPresent

            CSVString header = CSVData[0];//TODO case for wrong header
            //Parse header 
            OrderCSV order = new OrderCSV();
            int counter = 0;
            foreach (String i in header)
            {
                switch (i)
                {
                    case "title": order.title = counter; break;
                    case "desc": order.desc = counter; break;
                    case "deadline": order.deadline = counter; break;
                    case "tags": order.tags = counter; break;
                }
                counter++;
            }
            counter = 0;
            foreach (CSVString i in CSVData)
            {
                if (counter == 0)
                {
                    counter++;
                    continue;
                }

                DateTime deadline = DateTime.Parse(i[order.deadline]);
                ret.Add(new Item(i[order.title], i[order.desc], deadline, i[order.tags].Split(',').ToList()));
            }
            return ret;
        }

        public void ProgToCSV(IItemList nb)
        {
            CSVData.Clear();
            foreach (Item i in nb)
            {
                List<string> line = new List<string>();
                line.Add(i.Title);
                line.Add(i.Description);
                line.Add(i.DeadLine.ToString());
                line.Add(String.Join(",", i.Tags));

                CSVData.Add(new CSVString(line));
            }
        }
    }
}