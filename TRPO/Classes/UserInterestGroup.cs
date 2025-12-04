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
        long _interestGroup;
        DateTime _joinedAt;
        bool _isModerator;

        public long UserId {
            get => _userId;
            set
            {
                _userId = value;
                SetProperty(ref _userId, value);
            }
        }

        public long InterestGroup
        {
            get => _interestGroup;
            set {
                _interestGroup = value;
                SetProperty(ref _interestGroup, value);
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
    }
}
