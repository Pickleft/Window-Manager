# Window-Manager
Window Automation &amp; Management for .Net C#

# Getting Started :
  1. Manually adding the reference :
    1. Download the latest Release.
    2. Right click "References" in your solution explorer in Visual Studio 22.
    3. Click add reference.
    4. In the Browse tab click Browse.
    5. Head to the location of the downloaded Release and select it and double click it.

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
   
# Realses : 
  1. 1.0 -> Initial Release.
