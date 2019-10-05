using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SirHurtAPI_Demo_App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;
        [STAThread]
        static void Main()
        {
            FileInfo fileInfo = new FileInfo(Assembly.GetExecutingAssembly().Location);
            DateTime lastModified = fileInfo.LastWriteTime;
            Console.Title = "SirHurtAPI Demo App Launcher";
            Console.WriteLine("SirHurtAPI Demo App Launcher");
            Console.WriteLine("Build: " + lastModified.ToShortDateString().Replace("/", ""));
            Console.WriteLine("Build date: " + lastModified.ToString());
            Console.WriteLine("======================================");
            Console.WriteLine("Checking for required DLL...");
            if (File.Exists("SirHurtAPI.dll"))
            {
                Console.WriteLine("SirHurtAPI.dll - FOUND");
                Console.WriteLine("======================================");
            }
            else
            {
                Console.WriteLine("SirHurtAPI.dll - NOT FOUND");
                Console.WriteLine("Downloading SirHurtAPI.dll");
                //...
                Console.WriteLine("Downloaded.");
                Console.WriteLine("======================================");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
