using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TRPO.Classes;
using TRPO.Data;

namespace TRPO.Service
{
    public class UserService
    {
         readonly AppDbContext _db = BaseDbService.Instance.Context;

        public ObservableCollection<User> Users { get; set; } = new();

        public UserService()
        {
            GetAll();
        }
        public void Add(User user)
        {
            var _user = new User
            {
                Name = user.Name,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                CreatedAt = DateTime.Now,
                RoleId = user.RoleId,
                Role = user.Role,
                Profile = user.Profile ?? new UserProfile(),
               UserInterestGroups = user.UserInterestGroups,
            };
            _db.Add<User>(_user);
            Commit();
            Users.Add(_user);
        }
        public int Commit() => _db.SaveChanges();

        public void GetAll()
        {
            var users = _db.Users
               .Include(u => u.Role)     
               .Include(u => u.Profile)
               .Include(u => u.UserInterestGroups)
                  .ThenInclude(uig => uig.InterestGroup)
               .ToList();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
            
        }

        public void Update(User user)
        {
            _db.Users.Update(user);
            Commit();
             GetAll();
        }
    }
}
