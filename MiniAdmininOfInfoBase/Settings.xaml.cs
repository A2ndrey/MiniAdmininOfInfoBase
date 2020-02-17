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
                Properties.Settings.Default.UserName = UserPassword.Password;
            }

            if (UserPassword.Password.Length !=0)
            {
                Properties.Settings.Default.Password = UserName.Text;
            }

            Properties.Settings.Default.Save();
            this.Close();

        }

    }

}
