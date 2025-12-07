using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO.Classes;
using TRPO.Data;

namespace TRPO.Service
{
    public class InterestGroupService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;

        public ObservableCollection<InterestGroup> InterestGroups { get; set; } = new();

        public InterestGroupService()
        {
            GetAll();
        }

        public void GetAll()
        {
            var groups = _db.interestGroups
                .Include(ig => ig.UserInterestGroups)
                    .ThenInclude(uig => uig.User)
                        .ThenInclude(u => u.Profile)
                .ToList();

            InterestGroups.Clear();
            foreach (var group in groups)
            {
                InterestGroups.Add(group);
            }
        }

        public void Add(InterestGroup group)
        {
            var _group = new InterestGroup
            {
                ID = group.ID,
                Title = group.Title,
                Description = group.Description
            };
            _db.interestGroups.Add(_group);
            Commit();
            InterestGroups.Add(_group);
        }

        public void Update(InterestGroup group)
        {
            _db.interestGroups.Update(group);
            Commit();
            GetAll();
        }

        public void Remove(InterestGroup group)
        {
            _db.interestGroups.Remove(group);
            if (Commit() > 0)
            {
                if (InterestGroups.Contains(group))
                    InterestGroups.Remove(group);
            }
        }

        public int Commit() => _db.SaveChanges();
    }
}

