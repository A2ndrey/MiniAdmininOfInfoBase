using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Diagnostics;

namespace MiniAdmininOfInfoBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ConfirmExit()
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти?",
                                            "Выход",
                                            MessageBoxButton.YesNo,
                                            MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Settings SettingsWindows = new Settings();
            SettingsWindows.Owner = this;
            SettingsWindows.Show();
        }

        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Properties.Settings.Default.OneC_path);
            //  AboutBox1 lol = new AboutBox1();
            //  lol.Owner = this;
            //   lol.Show();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.ConfirmExit();
        }

        private void Browse_dt_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog BrowseDt = new Microsoft.Win32.OpenFileDialog();
            BrowseDt.Filter = "1c DataBase (.1cd)|*.1cd";

            Nullable<bool> result = BrowseDt.ShowDialog();
            if (result == true)
            {
                Save_cf_from_dt.Text = BrowseDt.FileName;
            }
        }

        private void Execute_Save_from_dt_Click(object sender, RoutedEventArgs e)
        {
            if (OneC_PathIdentified())
            {
                if (Save_cf_from_dt.Text.Length == 0)
                {
                    MessageBox.Show("Необходимо выбрать dt файл для выгрузки", "Информация", MessageBoxButton.OK);
                    return;
                }

                execute_1C_command("Save_cf_from_dt");
            }

        }

        private bool OneC_PathIdentified()
        {
            bool result = true;
            string OneC_Path = Properties.Settings.Default.OneC_path;
            string Description;
            if (OneC_Path.Length == 0)
            {
                Description = "Необходимо в настройках указать путь, к 1cv8.exe";
                MessageBox.Show(Description, "Ошибка", MessageBoxButton.OK);
                result = false;
            }

            return result;
        }

        private bool execute_1C_command(string CommandName)
        {
            bool result = true;
            string OneC_Path = Properties.Settings.Default.OneC_path;
            string UserName = Properties.Settings.Default.UserName;
            string Password = Properties.Settings.Default.Password;
            string OutPutBase = "D:\\TestBase.dt";
            // string MyExecuteCommand = "/k \"" + OneC_Path + "\" CONFIG /F " + Save_cf_from_dt.Text + " /N " + UserName + " /P " + Password + " /DumpIB " + OutPutBase;
            string MyExecuteCommand = "\"C:\\Program Files\\1cv8\\8.3.16.1063\\bin\\1cv8.exe\" CONFIG /F D:\\Базы\\ПодсистемаИнструментыРазработчика /DumpIB D:\\TestBase.dt";

            MessageBox.Show(MyExecuteCommand);


            //MyExecuteCommand.Replace("\\\\", "\\");
            //    MyExecuteCommand.Replace("\"", "\"");

            //Process process = new Process();
            //process.StartInfo.FileName = MyExecuteCommand; //"Save_cf_from_dt"
            //                                             //process.StartInfo.WorkingDirectory = "c:\temp";
            ////process.StartInfo.Arguments = "somefile.txt";
            //process.StartInfo.UseShellExecute = false;
            //process.StartInfo.RedirectStandardOutput = true;

            //process.Start();

            //Process.Start("cmd", "/k dir");
           // Process.Start("cmd", "/k " + MyExecuteCommand);
            Process.Start("cmd", "/c " + MyExecuteCommand);
            //StreamReader reader = process.StandardOutput;
            //string output = reader.ReadToEnd();
            //C:\Program Files\1cv8\bin\1cv8.exe" CONFIG /F D:\УпрТорг /N ИмяПользователя /P Пароль /DumpIB c:\имя.dt 

            //            string YourApplicationPath = "C:\\Program Files\\App\\MyApp.exe"
            //ProcessStartInfo processInfo = new ProcessStartInfo();
            //            processInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //            processInfo.FileName = "cmd.exe";
            //            processInfo.WorkingDirectory = Path.GetDirectoryName(YourApplicationPath);
            //            processInfo.Arguments = "/c START " + Path.GetFileName(YourApplicationPath);
            //            Process.Start(processInfo);

            return result;
        }

    }
}
