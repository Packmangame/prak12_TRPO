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
    /// Логика взаимодействия для GroupCompoundPage.xaml
    /// </summary>
    public partial class GroupCompoundPage : Page
    {
        public InterestGroup SelectedGroup { get; set; }
        public UserInterestGroupService UserInterestGroupService { get; set; } = new();
        public GroupCompoundPage(InterestGroup selectedGroup)
        {
            InitializeComponent();
            DataContext =this;
            SelectedGroup = selectedGroup;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }

        private void RemoveMember_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is UserInterestGroup userInterestGroup)
            {
                if (userInterestGroup.User != null)
                {
                    var result = MessageBox.Show(
                        $"Удалить пользователя {userInterestGroup.User.Name} из группы?",
                        "Подтверждение удаления",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        UserInterestGroupService.Remove(userInterestGroup);
                        
                        MessageBox.Show("Пользователь удален из группы");
                    }
                }
            }
           
        }
       
    }
}
