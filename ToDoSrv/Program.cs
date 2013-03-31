using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace ToDoSrv
{
    class Program
    {
        List<Thread> _threads;
        TcpListener _listener;
        static bool work_flag;

        public Program(int port)
        {
            _listener = new TcpListener(new IPEndPoint(IPAddress.Any,port));
            _listener.Start();
            _threads = new List<Thread>();
            work_flag = true;
        }

        public void DoWork()
        {
            do
            {
                Socket sck = _listener.AcceptSocket();
                ClientSession session = new ClientSession(sck);
                Thread sessionThread = new Thread(session.Start);
                lock (_threads)
                    _threads.Add(sessionThread);
                sessionThread.Start();
            } while (work_flag);

            foreach (Thread i in _threads)
                if (!i.IsAlive)
                    i.Join();
        }

        static void CancelHandler(object sender, ConsoleCancelEventArgs args)
        {
            if (args.Cancel)
                work_flag = false;
        }

        static void Main(string[] args)
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(CancelHandler);
            int port;
            if (!int.TryParse(args[0], out port))
            {
                Console.WriteLine("Wrong command line args");
                return;
            }
            Program program = new Program(port);
            program.DoWork();
        }
    }
}
