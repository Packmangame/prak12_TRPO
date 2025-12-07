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
using TRPO.Classes;
using TRPO.Service;

namespace TRPO
{
    /// <summary>
    /// Логика взаимодействия для AddMemberWindow.xaml
    /// </summary>
    public partial class AddMemberWindow : Window
    {
        public InterestGroup Group { get; set; }
        public User SelectedUser { get; set; }
        public UserService UserService { get; set; } = new UserService();
        public DateTime JoinedAt { get; set; } = DateTime.Now;
        public bool IsModerator { get; set; }
        public AddMemberWindow(InterestGroup group)
        {
            InitializeComponent();
            Group = group;
            DataContext = this;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedUser == null)
            {
                MessageBox.Show("Выберите пользователя");
                return;
            }

            var userInterestGroup = new UserInterestGroup
            {
                UserId = SelectedUser.ID,
                InterestGroupID = Group.ID,
                JoinedAt = JoinedAt,
                IsModerator = IsModerator,
                User = SelectedUser,
                InterestGroup = Group
            };

            var service = new UserInterestGroupService();
            service.Add(userInterestGroup);

            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
