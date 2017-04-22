using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            Console.WriteLine("Result: {0}", result);
            Console.ReadKey();
        }
    }
}
