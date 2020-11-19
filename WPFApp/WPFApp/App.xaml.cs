using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPFApp
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private string globalatom;//原子 AppDomain.CurrentDomain.FriendlyName=>"WPFApp.exe" 
        public App()
        {
            globalatom = AppDomain.CurrentDomain.FriendlyName;
            RunOneApplication();
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            //退出程序时要记得释放特定的原子A哦，不然要到关机才会释放
            GlobalDeleteAtom(GlobalFindAtom(globalatom));//删除原子
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            //初始化一些其他的设置
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //MessageBox.Show("CurrentDomain_UnhandledException捕获异常");
            DeleteAtom();
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            //MessageBox.Show("TaskScheduler_UnobservedTaskException捕获异常");
            DeleteAtom();
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //MessageBox.Show("App_DispatcherUnhandledException捕获异常");
            DeleteAtom();
        }

        private void RunOneApplication()
        {
            //GlobalDeleteAtom(GlobalFindAtom(globalatom));//删除原子
            if (GlobalFindAtom(globalatom) == 0) //没找到原子"WPFApp.exe" 
            {
                GlobalAddAtom(globalatom); //添加原子"WPFApp.exe"
            }
            else
            {
                MessageBox.Show("已经运行了一个实例了。");
                //设置窗体显示最前端
                //IntPtr mainHandle = FindWindow(null, "柜外清设备监视器");
                //if (mainHandle != IntPtr.Zero)
                //{
                //    //通过句柄设置当前窗体最大化（0：隐藏窗体，1：默认窗体，2：最小化窗体，3：最大化窗体，....）
                //    ShowWindowAsync(mainHandle, 2);
                //    SetForegroundWindow(mainHandle);
                //}
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 删除原子标记
        /// </summary>
        private void DeleteAtom()
        {
            GlobalDeleteAtom(GlobalFindAtom(globalatom));//删除原子
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern UInt32 GlobalAddAtom(String lpString); //添加原子 
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern UInt32 GlobalFindAtom(String lpString); //查找原子 
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern UInt32 GlobalDeleteAtom(UInt32 nAtom); //删除原子

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "ShowWindowAsync")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
    }
}
