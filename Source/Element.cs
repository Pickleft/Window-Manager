using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Window_Manager
{
    public class Element
    {
        public IntPtr Pointer { get; }
        public IntPtr ParentPointer { get; }
        public Element(IntPtr ElementPointer, IntPtr parentPointer)
        {
            Pointer = ElementPointer;
            ParentPointer = parentPointer;
        }

        /// <summary>
        /// Gets the Classname of the Element.
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
        /// Gets / Sets the text of the Element.
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
        /// Gets / Sets the location of the Element to the Parent Window.
        /// </summary>
        public Point Location
        {
            get
            {
                WinApi.GetWindowRect(Pointer, out Rectangle rec);
                WinApi.GetWindowRect(ParentPointer, out Rectangle rec_parent);
                Point p = new Point(rec.Location.X - rec_parent.Location.X, rec.Location.Y - rec_parent.Location.Y);
                return p;
            }
            set
            {
                WinApi.SetWindowPos(Pointer, 0, value.X, value.Y, 0, 0, 0x0001);
            }
        }

        /// <summary>
        /// Gets / Sets the Enabled State of the Element.
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
        /// Click an Element (without using cursor automation).
        /// </summary>
        /// <remarks>         
        /// Might not work on first attempt.
        /// </remarks>
        public void Click()
        {
            WinApi.SendMessage(Pointer, 0x201, 0x0001, 0);
            WinApi.SendMessage(Pointer, 0x202, 0, 0);
        }

        public static List<Element> operator +(Element obj1, Element obj2)
        {
            return new List<Element> { obj1, obj2 };
        }
        public static List<Element> operator +(List<Element> obj1, Element obj2)
        {
            return obj1.Append(obj2).ToList();
        }
    }
}
