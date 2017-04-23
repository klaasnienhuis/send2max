using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace console_demo
{
    class Program
    {


        static void Main(string[] args)
        {
            //StringBuilder sb = new StringBuilder("filein @\"" + scriptPath + "\"\r\n");
            StringBuilder sb = new StringBuilder("teapot()\r\n");
            int result = WindowHandleInfo.Send2Max(sb);





            Process[] processlist = Process.GetProcesses();

            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    Console.WriteLine("Process: {0} ID: {1} Window title: {2}", process.ProcessName, process.Id, process.MainWindowTitle);
                }
            }


            Console.WriteLine("Result: {0}", result.ToString());
            Console.ReadKey();
        }
    }
}
