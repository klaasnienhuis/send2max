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
            //First find the 3dsMax processes running
            Process[] processes = MaxScript.Send2Max.Get3dsMaxProcesses();
            List<Process> scriptTargetProcess = new List<Process>();

            //Logic going through three scenarios: max isn't running, one max is running, multiple maxes are running
            if (processes.Length == 0) Console.WriteLine("No 3ds Max instance found. Can't send the script, sorry");
            if (processes.Length == 1)
            {
                Console.WriteLine("Found one 3ds Max instance found. Sending the script now");
                scriptTargetProcess.Add(processes[0]);
            }
            if (processes.Length > 1)
            {
                Console.WriteLine("Found {0} 3ds Max instance running. Which one do you want to use?", processes.Length);
                for (int n = 0; n < processes.Length;n++)
                {
                    Console.WriteLine("[{0}]: {1}",n,processes[n].MainWindowTitle);
                }
                Console.WriteLine("[{0}]: All of them",processes.Length);
                ConsoleKeyInfo info = Console.ReadKey();
                Console.WriteLine();
                int val;
                Console.WriteLine("You pressed " + info.KeyChar.ToString());
                if (int.TryParse(info.KeyChar.ToString(), out val))
                {
                    if (val <= processes.Length)
                    {
                        if (val == processes.Length)
                        {
                            scriptTargetProcess = processes.ToList<Process>();
                        }
                        else
                        {
                            scriptTargetProcess.Add(processes[val]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("{0} is not a valid choice, please run the tool again, bye!", info.KeyChar.ToString());
                }
            }

            //Send the script
            foreach (Process p in scriptTargetProcess)
            {
                //StringBuilder sb = new StringBuilder("filein @\"" + scriptPath + "\"\r\n");
                StringBuilder sb = new StringBuilder("teapot()\r\n");
                int result = MaxScript.Send2Max.Send(sb,p.MainWindowHandle);
                Console.WriteLine("Result: {0}", result.ToString());

            }

            Console.WriteLine("Press a key to exit the program");
            Console.ReadKey();
        }
    }
}
