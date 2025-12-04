using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO.Classes
{
    public class UserProfile : ObservableObject
    {
        static string defaultAvatarPath = System.IO.Path.Combine(AppContext.BaseDirectory, @"SRC\default.jpg");
        long _id;
        long _userID;
        string _phoneNumber;
        string _avatarUrl= System.IO.Path.Combine(AppContext.BaseDirectory, @"SRC\default.jpg");
        DateTime _birthday =DateTime.Today;
        string _bio;

        User _user;

        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    SetProperty(ref _id, value);
                }
            }
        }

        public string AvaterlUrl
        {
            get => _avatarUrl;
            set
            {
                _avatarUrl = string.IsNullOrEmpty(value) ? defaultAvatarPath : value;
                SetProperty(ref _avatarUrl, value);
            }
        }
        public string Phone
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                SetProperty(ref _phoneNumber, value);

            }
        }
        public DateTime BirthDay
        {
            get => _birthday;
            set
            {
                _birthday = _birthday = value == default(DateTime) ? DateTime.Today : value;
                SetProperty(ref _birthday, value);
            }
        }
        public string? BIO
        {
            get => _bio;
            set
            {
                var safeValue = string.IsNullOrEmpty(value) ? "_" : value;
                SetProperty(ref _bio, safeValue);
            }
        }

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                SetProperty(ref _user, value);
            }
        }
        public long UserId
        {
            get => _userID;
            set
            {
                _userID = value;
                SetProperty(ref _userID, value);
            }
        }
    }
}