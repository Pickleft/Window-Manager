using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Window_Manager
{
    public class Window
    {
        public IntPtr Pointer { get; }
        public List<Element> Elements { get; protected set; }

        public Window(IntPtr WindowPointer)
        {
            Pointer = WindowPointer;
            Elements = new List<Element>();
            WinApi.EnumChildWindows(Pointer, new EnumWindowsProc(GetElements), IntPtr.Zero);
        }

        /// <summary>
        /// Gets every Element in the Window. Called By "EnumChildWindows" / Check EnumChildWindows Class.
        /// </summary>
        /// <param name="ElementPointer"></param>
        /// <param name="parm"></param>
        private bool GetElements(IntPtr ElementPointer, int parm)
        {
            Element element = new Element(ElementPointer, Pointer);
            Elements += element;
            return true;
        }

        /// <summary>
        /// Gets the Classname of the Window.
        /// </summary>
        public string ClassName
        {
            get
            {
                StringBuilder builder = new StringBuilder(999);
                WinApi.GetClassName(Pointer, builder, 999);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Gets / Sets the text of the Window.
        /// </summary>
        public string Text
        {
            get
            {
                StringBuilder builder = new StringBuilder(999);
                WinApi.GetWindowText(Pointer, builder, 999);
                return builder.ToString();
            }
            set
            {
                WinApi.SetWindowText(Pointer, value);
            }
        }

        /// <summary>
        /// Sets the window visible state. Check ShowWindow class.
        /// </summary>
        /// <param name="option">
        /// A WindowProperties enum value.
        /// </param>
        /// <returns>Whether was the operation successful</returns>
        public bool SetWindowVisibility(WindowProperties option)
        {
            return WinApi.ShowWindow(Pointer, (int)option);
        }

        /// <summary>
        /// Gets / Sets the location of the Window to the Parent Window.
        /// </summary>
        public Point Location
        {
            get
            {
                WinApi.GetWindowRect(Pointer, out Rectangle rec);
                Point p = new Point(rec.Location.X - rec.Left, rec.Location.Y - rec.Top);
                return p;
            }
            set
            {
                WinApi.SetWindowPos(Pointer, 0, value.X, value.Y, 0, 0, 0x0001);
            }
        }

        /// <summary>
        /// Gets / Sets the Enabled State of the Window.
        /// </summary>
        public bool Enabled
        {
            get
            {
                return WinApi.IsWindowEnabled(Pointer);
            }
            set
            {
                WinApi.EnableWindow(Pointer, value);
            }
        }

        /// <summary>
        /// Gets whether the Window is visible or not.
        /// </summary>
        public bool IsVisible
        {
            get
            {
                return WinApi.IsWindowVisible(Pointer);
            }
        }

        /// <summary>
        /// Closes the current Window.
        /// </summary>
        public bool Close()
        {
            return WinApi.CloseWindow(Pointer);
        }

        public static List<Window> operator +(Window obj1, Window obj2)
        {
            return new List<Window> { obj1, obj2 };
        }
        public static List<Window> operator +(List<Window> obj1, Window obj2)
        {
            return obj1.Append(obj2).ToList();
        }
    }
}
