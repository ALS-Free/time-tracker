using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Data.SqlClient;

namespace BM_TimeTracker
{


    static class Program
    {

        [DllImport("user32.dll")]
        private static extern
            bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern
            bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern
            bool IsIconic(IntPtr hWnd);

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                if (AlreadyRunning())
                {
                    return;
                }
                //Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                // AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new fLogin());
                // throw new Exception();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                MessageBox.Show(Ressources.strings.global_horribleException + "\n" + ((Exception)sender).Message);
            }
        }

        static void CatchThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                MessageBox.Show(Ressources.strings.global_horribleException + "\n" + ((Exception)sender).Message);
            }
        }

        private static bool AlreadyRunning()
        {
            /*
                  const int SW_HIDE = 0;
                  const int SW_SHOWNORMAL = 1;
                  const int SW_SHOWMINIMIZED = 2;
                  const int SW_SHOWMAXIMIZED = 3;
                  const int SW_SHOWNOACTIVATE = 4;
                  const int SW_RESTORE = 9;
                  const int SW_SHOWDEFAULT = 10;
                  */
            const int swRestore = 9;

            var me = Process.GetCurrentProcess();
            var arrProcesses = Process.GetProcessesByName(me.ProcessName);

            if (arrProcesses.Length > 1)
            {
                for (var i = 0; i < arrProcesses.Length; i++)
                {
                    if (arrProcesses[i].Id != me.Id)
                    {
                        // get the window handle
                        IntPtr hWnd = arrProcesses[i].MainWindowHandle;

                        // if iconic, we need to restore the window
                        if (IsIconic(hWnd))
                        {
                            ShowWindowAsync(hWnd, swRestore);
                        }

                        // bring it to the foreground
                        SetForegroundWindow(hWnd);
                        break;
                    }
                }
                return true;
            }

            return false;
        }

    }
}
