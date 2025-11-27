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
        User user=new();
        bool _isEdit;
        public RegistrationScreen(User? _edituser = null)
        {
            InitializeComponent();
            
            if (_edituser != null)
            {
                this.user = _edituser;
                _isEdit = true;
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
            NavigationService.Navigate(new MainScreen());
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainScreen());
        }

        
    }
}
