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

using OneC_Class;

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

            Nullable<bool> result = BrowseDt.ShowDialog(null);
            if (result == true)
            {
                Path_CD.Text = BrowseDt.FileName;
            }
        }

        private void Execute_Save_from_dt_Click(object sender, RoutedEventArgs e)
        {
            if (OneC_PathIdentified())
            {
                if (Path_CD.Text.Length == 0)
                {
                    MessageBox.Show("Необходимо выбрать dt файл для выгрузки", "Информация", MessageBoxButton.OK);
                    return;
                }

                OneCExecuteCommand OneC_command = new OneCExecuteCommand();
                OneC_command.OneCComandName = "SaveDtFromCD";
                OneC_command.inputFile = Path_CD.Text;
                OneC_command.outputFile = "D:\\TestBase.dt";
                OneC_command.OneC_Path = Properties.Settings.Default.OneC_path;
                OneC_command.username = Properties.Settings.Default.UserName;
                OneC_command.password = Properties.Settings.Default.Password;

                string result = OneC_command.OnecExecute();
                MessageBox.Show(result);
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


    }
}
