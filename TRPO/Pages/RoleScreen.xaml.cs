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
    /// Логика взаимодействия для RoleScreen.xaml
    /// </summary>
    public partial class RoleScreen : Page
    {
        public RoleService _service = new();
        private Role? _selectedRole;

        public Role? SelectedRole
        {
            get => _selectedRole;
            set
            {
                _selectedRole = value;
            }
        }

        public Role? NewRole { get; set; } = new();

        public RoleScreen()
        {
            InitializeComponent();
            DataContext = this;
            Add_role_place.DataContext = NewRole;
            _service.GetAll();
        }

        private void Add_Role(object sebnder, RoutedEventArgs e)
        {
            _service.Add(NewRole);
            _service.GetAll();
        }
        private void Back(object sebnder, RoutedEventArgs e)
        {
           NavigationService.GoBack();
        }

        private void ViewUsers_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedRole != null)
            {
                // Переходим на страницу просмотра пользователей роли
                NavigationService?.Navigate(new RoleUsersPage(SelectedRole));
            }
        }

    }
}
