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
         //   SettingsWindows.ShowViewModel();
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
           // this.Close();
        }
    }
}
