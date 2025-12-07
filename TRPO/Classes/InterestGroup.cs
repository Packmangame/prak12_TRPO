using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO.Classes
{
    public class InterestGroup:ObservableObject
    {
        long _id;
        string _title;
        string _description;

        ObservableCollection<UserInterestGroup> _userInterestGroups;
        public long ID 
        {
            get => _id;
            set
            {
                _id = value;
                SetProperty(ref _id, value);
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                SetProperty(ref _title, value);
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                SetProperty(ref _description, value);
            }
        }
        public ObservableCollection<UserInterestGroup> UserInterestGroups
        {
            get => _userInterestGroups;
            set => SetProperty(ref _userInterestGroups, value);
        }
    }
}
