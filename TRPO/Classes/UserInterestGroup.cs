using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO.Classes
{
    public class UserInterestGroup : ObservableObject
    {
        long _userId;
        long _interestGroupID;
        DateTime _joinedAt;
        bool _isModerator;

        User _user;
        InterestGroup _interestGroup;

        public long UserId {
            get => _userId;
            set
            {
                _userId = value;
                SetProperty(ref _userId, value);
            }
        }

        public long InterestGroupID
        {
            get => _interestGroupID;
            set {
                _interestGroupID = value;
                SetProperty(ref _interestGroupID, value);
            }
        }

        public DateTime JoinedAt
        {
            get => _joinedAt;
            set
            {
                _joinedAt = value;
                SetProperty(ref _joinedAt, value);
            }
        }

        public bool IsModerator
        {
            get => _isModerator;
            set
            {
                _isModerator = value;
                SetProperty(ref _isModerator, value);
            }

        }

        public User User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public InterestGroup InterestGroup
        {
            get => _interestGroup;
            set => SetProperty(ref _interestGroup, value);
        }
    }
}
