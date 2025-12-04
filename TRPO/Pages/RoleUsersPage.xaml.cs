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
    /// Логика взаимодействия для RoleUsersPage.xaml
    /// </summary>
    public partial class RoleUsersPage : Page
    {
        private readonly Role _role;
        private readonly UserService _userService;
        private List<User> _users;

        public RoleUsersPage(Role role)
        {
            InitializeComponent();
            _role = role;
            _userService = new UserService();

            LoadUsers();
            UpdateUI();
        }

        private void LoadUsers()
        {


            _userService.GetAll();
            _users = _userService.Users
                .Where(u => u.RoleId == _role.Id)
                .ToList();

            UsersListView.ItemsSource = _users;
        }

        private void UpdateUI()
        {
            RoleTitle.Text = $"Роль: {_role.Title}";
            UsersCount.Text = $"Количество пользователей: {_users?.Count ?? 0}";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }

    }
}
