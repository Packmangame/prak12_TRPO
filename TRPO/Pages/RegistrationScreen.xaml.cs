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
using TRPO.Classes;
using TRPO.Service;

namespace TRPO.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationScreen.xaml
    /// </summary>
    public partial class RegistrationScreen : Page
    {
        UserService userService = new ();
        User user;
        bool _isEdit;
        public RegistrationScreen(User? user = null)
        {
            InitializeComponent();
            if (user != null)
            {
                this.user = user;
                _isEdit = true;
            }
            else
            {
                user = new User();
            }
            this.DataContext=user;
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            if (_isEdit == true)
            {
                userService.Commit();
            }
            else
            {
               
                userService.Add(user);
                userService.Commit();
            }
            MessageBox.Show("Отлично", "Сообщение", MessageBoxButton.OK);
            NavigationService.GoBack();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        
    }
}
