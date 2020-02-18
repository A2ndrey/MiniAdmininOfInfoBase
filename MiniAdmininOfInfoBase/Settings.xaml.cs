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
using System.Windows.Shapes;

namespace MiniAdmininOfInfoBase
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public bool needToSave = false;

        public Settings()
        {
            InitializeComponent();

            loadValueOfSettings();
        }

        private void loadValueOfSettings()
        {
            if (Properties.Settings.Default.OneC_path.Length > 0)
            {
                OneC_Path.Text = Properties.Settings.Default.OneC_path;
            }

            if (Properties.Settings.Default.UserName.Length > 0)
            {
                UserName.Text = Properties.Settings.Default.UserName;
            }

            if (Properties.Settings.Default.Password.Length > 0)
            {
                UserPassword.Password = Properties.Settings.Default.Password;
            }
        }

        //public void ShowViewModel()
        //{
        //    MessageBox.Show(ViewModel);
        //}

     
        public void OneC_PathIsEmpty(string Description)
        {
            MessageBox.Show(Description,"Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            if (OneC_Path.Text.Length == 0)
            {
                this.OneC_PathIsEmpty("Необходимо указать путь к исполняемому файлу");
                return;
            }

            Properties.Settings.Default.OneC_path = OneC_Path.Text;
            
            if (UserName.Text.Length != 0)
            {
                Properties.Settings.Default.UserName = UserName.Text;
            }

            if (UserPassword.Password.Length !=0)
            {
                Properties.Settings.Default.Password = UserPassword.Password;
            }

            Properties.Settings.Default.Save();
            this.Close();

        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog oneCPathDialog = new Microsoft.Win32.OpenFileDialog();
            oneCPathDialog.Filter = "1cv8.exe (*.exe)|1cv8.exe";
            oneCPathDialog.FilterIndex = 2;

            Nullable<bool> result = oneCPathDialog.ShowDialog();

            if (result == true)
            {
                OneC_Path.Text = oneCPathDialog.FileName.Replace( "\\\\", "\\" );
            }
        }
    }

}
