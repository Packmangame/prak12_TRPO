using Microsoft.Win32;

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
        RoleService roleService = new ();
        User user=new();
        UserProfile _profile = new();
        bool _isEdit;
        public RegistrationScreen(User? _edituser = null)
        {
            InitializeComponent();
            
            if (_edituser != null)
            {
                this.user = _edituser;
                this._profile = _edituser.Profile;
                _isEdit = true;
            }
            else
            {
                this.user = new User()
                {
                    RoleId = 1,
                    Profile= _profile,
                };
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
            }
            NavigationService.Navigate(new MainScreen());
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainScreen());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
              _profile.AvaterlUrl = openFileDialog.FileName;

            userService.GetAll();
            roleService.GetAll();
        }
    }
}
