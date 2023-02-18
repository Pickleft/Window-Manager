using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Window_Manager
{
    public class WindowThread
    {
        public List<Window> Windows { get; protected set; }
        public IntPtr ThreadPointer { get; }
        public int ID { get; }
        public WindowThread(ProcessThread thread)
        {
            ThreadPointer = thread.StartAddress;
            ID = thread.Id;
            Windows = new List<Window>();
            WinApi.EnumThreadWindows(thread.Id, new EnumThreadDelegate(GetWindow), IntPtr.Zero);
        }
        /// <summary>
        /// Gets all Windows associated with the current thread. Called By "EnumThreadWindows" / Check EnumThreadWindows Class.
        /// </summary>
        /// <param name="pointer"></param>
        /// <param name="parm"></param>
        /// <returns></returns>
        private bool GetWindow(IntPtr pointer, IntPtr parm) // The 2nd-argument "parm" is obsolete.
        {
            Window window = new Window(pointer);
            Windows += window;
            return true;
        }

        public static WindowThread Create(ProcessThread thread)
        {
            return new WindowThread(thread);
        }
    }
}
