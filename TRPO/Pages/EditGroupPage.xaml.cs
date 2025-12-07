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
    /// Логика взаимодействия для EditGroupPage.xaml
    /// </summary>
    public partial class EditGroupPage : Page
    {
        public InterestGroup Group { get; set; }
        private InterestGroupService _interestGroupService = new InterestGroupService();
        private bool _isEditing = false;
        public EditGroupPage()
        {
            InitializeComponent();
            Group = new InterestGroup();
            DataContext = this;
        }

        public EditGroupPage(InterestGroup groupToEdit)
        {
            InitializeComponent();
            Group = groupToEdit;
            _isEditing = true;
            DataContext = this;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
           
            if (_isEditing)
            {
                _interestGroupService.Update(Group);
            }
            else
            {
                _interestGroupService.Add(Group);
            }

            NavigationService?.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}
