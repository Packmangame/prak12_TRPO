using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TRPO.Classes;
using TRPO.Data;

namespace TRPO.Service
{
    public class RoleService
    {
        readonly AppDbContext _db = BaseDbService.Instance.Context;
       public static ObservableCollection<Role> Roles { get; set; } = new();

        public void GetAll()
        {
            var roles = _db.Roles
              .Include(r => r.Users) 
              .ToList();
            Roles.Clear();
            foreach (var role in roles)
            {
                Roles.Add(role);
            }
        }

        public int Commit() => _db.SaveChanges();

        public RoleService()
        {
            GetAll();
        }

        public void Add(Role role)
        {
            var _role = new Role
            {
                Title = role.Title,
            };
            _db.Add<Role>(_role);
            Commit();
            Roles.Add(_role);
        }

        public void Remove(Role role)
        {
            _db.Remove<Role>(role);
            if (Commit() > 0)
            {
                if (Roles.Contains(role))
                {
                    Roles.Remove(role);
                }
            }

        }
    }
}
