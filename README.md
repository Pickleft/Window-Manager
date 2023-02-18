# Window-Manager
Window Automation &amp; Management for .Net C#

# Getting Started :
 * Manually adding the reference :
   * Download the latest Release.
   * Download the latest Release.
   * Right click "References" in your solution explorer in Visual Studio 22.
   * Click add reference.
   * In the Browse tab click Browse.
   * Head to the location of the downloaded Release and select it and double click it.

### No Documentation At This Moment.

# Usage
 * The **XML documentation** in the source is *self-explanatory*.
 * Usage, for instance :
 ```cs
            Process[] procs = Process.GetProcessesByName("Clicker");
            foreach (Process proc in procs)
            {
                foreach (ProcessThread thread in proc.Threads)
                {
                    WindowThread windowthread = new WindowThread(thread);
                    foreach (Window win in windowthread.Windows)
                    {
                        win.SetWindowVisibility(WindowProperties.SHOW);
                        Console.WriteLine(String.Format("-> Window-Text : {0}", win.Text));
                        foreach (Element element in win.Elements)
                        {
                            Console.WriteLine(String.Format("    Control-Text : {0}", element.Text));
                        }
                    }
                }
            }
 ```
 * **OutPut** 
 ```
    -> Window-Text : Menu
        Control-Text :
        Control-Text :
        Control-Text :
        Control-Text :
        Control-Text : Info :
        Control-Text : Version : 1.4.3
        Control-Text : Build N° : 8438
        Control-Text : Inspired By Bolt.
        Control-Text : ?? By Pickleft#1853 ??
        Control-Text : ?Swift
        Control-Text :
        Control-Text : _
        Control-Text : Destruct
        Control-Text : Customize
        Control-Text : Home
        Control-Text : Clicker
    -> Window-Text : .NET-BroadcastEventWindow.4.0.0.0.141b42a.0
    -> Window-Text : MSCTFIME UI
    -> Window-Text : Default IME
    -> Window-Text : GDI+ Window (Clicker.exe)
    -> Window-Text : Default IME
 ```
 * The Process "Clicker" & The Window "Menu" 
 * ![The Process "Clicker" & The Window "Menu"](https://user-images.githubusercontent.com/76597572/219881554-bfde7111-e353-42d9-9b37-7c513e37954d.png)
 
# Realses : 
 1. 1.0 -> Initial Release.
