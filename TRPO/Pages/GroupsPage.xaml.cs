using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для GroupsPage.xaml
    /// </summary>
    public partial class GroupsPage : Page
    {
      
        public User SelectedUser { get; set; } = new();
        public InterestGroupService InterestGroupService { get; set; } = new();
        public UserService UserService { get; set; } = new();
        public UserInterestGroupService UserInterestGroupService { get; set; } = new();
       
       
        private InterestGroup _selectedGroup;
        public InterestGroup SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                _selectedGroup = value;
            }
        }
     

        public GroupsPage()
        {
            InitializeComponent();
            DataContext = this;
            RefreshPage();
            
           
        }

        private void GroupList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
          NavigationService?.Navigate(new Pages.GroupCompoundPage(SelectedGroup));
            
            
        }

        private void UserGroupsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListView listView && listView.SelectedItem is UserInterestGroup userInterestGroup)
            {
                if (userInterestGroup.InterestGroup != null)
                {

                    SelectedGroup = userInterestGroup.InterestGroup;

                }
            }
        }
        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Pages.EditGroupPage());
        }

        private void EditGroup_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGroup != null && SelectedGroup.ID > 0)
            {
                NavigationService?.Navigate(new Pages.EditGroupPage(SelectedGroup));
            }
            else
            {
                MessageBox.Show("Выберите группу для редактирования");
            }
        }

        private void DeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGroup != null && SelectedGroup.ID > 0)
            {
                var result = MessageBox.Show($"Удалить группу '{SelectedGroup.Title}'?",
                    "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    InterestGroupService.Remove(SelectedGroup);
                }
            }
            else
            {
                MessageBox.Show("Выберите группу для удаления");
            }
        }

        private void AddMember_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGroup == null || SelectedGroup.ID == 0)
            {
                MessageBox.Show("Выберите группу для добавления участника");
                return;
            }


            var addMember = new AddMemberWindow(SelectedGroup);
            addMember.ShowDialog();


            RefreshPage();
        }

        public void SelectUser(User user)
        {
            SelectedUser = user;

            if (SelectedUser != null)
            {
                var userGroups = UserInterestGroupService.GetUserGroups(SelectedUser.ID);
                SelectedUser.UserInterestGroups = new System.Collections.ObjectModel.ObservableCollection<UserInterestGroup>(userGroups);
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }

       
        private void RefreshPage()
        {
            
            UserService.GetAll();
            InterestGroupService.GetAll();
        }
    }
}
