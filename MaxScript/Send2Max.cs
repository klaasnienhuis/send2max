using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MaxScript
{
    public static class Send2Max
    {
        private delegate bool EnumChildProc(IntPtr hwnd, ref SearchData data);

        public static int WM_SETTEXT = 0x000C; //send a string
        public static int WM_CHAR = 0x0102; //send a single character
        public static int VK_RETURN = 0x000D; //the return character

        /// <summary>
        /// Send a message to a window.
        /// </summary>
        /// <param name="hwnd">the handle of the window</param>
        /// <param name="msg"></param>
        /// <param name="messageLength"></param>
        /// <param name="theMessage">the actual message</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int msg, IntPtr messageLength, [MarshalAs(UnmanagedType.LPStr)] string theMessage);

        /// <summary>
        /// Get the name of a window. Feeds the name into the stringbuilder
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpClassName"></param>
        /// <param name="nMaxCount"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        /// <summary>
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms633494(v=vs.85).aspx
        /// Enumerates the child windows that belong to the specified parent window by passing the 
        /// handle to each child window, in turn, to an application-defined callback function. 
        /// EnumChildWindows continues until the last child window is enumerated or the callback 
        /// function returns FALSE.
        /// </summary>
        /// <param name="hWndParent">The handle of the parent window</param>
        /// <param name="callback">The function we're running with the handle of each child window</param>
        /// <param name="data">This data is passed into the callback. We use it to keep track of the 
        /// name and handle of the window we're looking for.</param>
        /// <returns></returns>
        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr hWndParent, EnumChildProc callback, ref SearchData data);

        /// <summary>
        /// Enumerate all childwindows of a specific handle and look for a window with 
        /// a certain name
        /// </summary>
        /// <param name="hwnd">The handle of the parent window</param>
        /// <param name="classname">The name of the window we're looking for</param>
        /// <returns></returns>
        private static SearchData GetAllChildHandles(IntPtr hwnd, string classname)
        {
            SearchData sd = new SearchData { windowName = classname }; //the searchdata object contains the name of the window we're looking for
            EnumChildProc childProc = new EnumChildProc(EnumChildWindowCallback); //setup the callback function
            EnumChildWindows(hwnd, childProc, ref sd); //check all child windows
            return sd;
        }

        /// <summary>
        /// Get the name of a window and compare it to the name we're looking for.
        /// Used as callback in the EnumChildWindows method. If this returns true
        /// it keeps running, if it returns false, we've found the window and we
        /// can stop enumerating.
        /// </summary>
        /// <param name="hWndChild"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private static bool EnumChildWindowCallback(IntPtr hWndChild, ref SearchData data)
        {
            StringBuilder sb = new StringBuilder(1024);
            GetClassName(hWndChild, sb, sb.Capacity);
            if (sb.ToString().StartsWith(data.windowName))
            {
                data.hWnd = hWndChild;
                return false;
            }
            return true;
        }

        public static Process[] Get3dsMaxProcesses()
        {
            Process[] myMax = Process.GetProcessesByName("3dsmax");
            return myMax;
        }


        /// <summary>
        /// Send a message to the script editor of 3dsMax. Uses the first open 3dsMax
        /// it can find
        /// </summary>
        /// <param name="theScript"></param>
        /// <returns></returns>
        public static void Send(StringBuilder theScript, IntPtr mawWindowHandle)
        {
            //find a script editor. There are multiple, one will do
            SearchData sd = GetAllChildHandles(mawWindowHandle, "MXS_Scintilla");

            Console.WriteLine("Scintilla script window handle: {0}", sd.hWnd);
            Console.WriteLine("Script sent: {0}", theScript.ToString());

            //first send the script
            SendMessage(sd.hWnd, WM_SETTEXT, (IntPtr)theScript.Length, theScript.ToString());
            //then press enter to execute
            SendMessage(sd.hWnd, WM_CHAR, (IntPtr)VK_RETURN, null);
        }

    }
}
