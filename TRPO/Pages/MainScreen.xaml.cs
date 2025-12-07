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
    /// Логика взаимодействия для MainScreen.xaml
    /// </summary>
    public partial class MainScreen : Page
    {
        public User user { get; set; } = new();
        public UserService UserService { get; set; } = new();
        public MainScreen()
        {
            InitializeComponent();
            UserService.GetAll();
        }

        void AddUser(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Pages.RegistrationScreen());
        }
        void UsersRole(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Pages.RoleScreen());
        }
        void Edit(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Pages.RegistrationScreen(user));
        }

        void ShowUserGroups(object sender, RoutedEventArgs e)
        {
            if (user != null && user.ID > 0)
            {
                var groupsPage = new Pages.GroupsPage();
                groupsPage.SelectUser(user); 
                NavigationService?.Navigate(groupsPage);
            }
            else
            {
                MessageBox.Show("Выберите пользователя для просмотра его групп");
            }
        }
    }
}
