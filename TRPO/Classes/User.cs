using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TRPO.Classes
{
    public class User : ObservableObject
    {
        long _id;
        string _login;
        string _name;
        string _email;
        string _password;
        DateTime _createdAt;

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

        public string Login
        {
            get => _login;
            set
            {
                if (_login != value)
                {
                    _login = value;
                    SetProperty(ref _login, value);
                }
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {

                    _name = value;
                    SetProperty(ref _name, value);
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    SetProperty(ref _email, value);
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value != _password)
                {
                    _password = value;
                    SetProperty(ref _password, value);
                }
            }
        }

        public DateTime CreatedAt
        {
            get => _createdAt;
            set
            {
                if (_createdAt != value)
                    _createdAt = value;
                SetProperty(ref _createdAt, value);
            }
        }

        
    }
}
