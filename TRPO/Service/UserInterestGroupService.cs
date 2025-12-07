using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO.Classes;
using TRPO.Data;

namespace TRPO.Service
{
    public class UserInterestGroupService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;

        public void Add(UserInterestGroup userInterestGroup)
        {
            var _userInterestGroup = new UserInterestGroup
            {
                UserId = userInterestGroup.UserId,
                InterestGroupID = userInterestGroup.InterestGroupID,
                JoinedAt = userInterestGroup.JoinedAt,
                IsModerator = userInterestGroup.IsModerator
            };
            _db.userInterestGroups.Add(_userInterestGroup);
            _db.SaveChanges();
        }

        public void Remove(UserInterestGroup userInterestGroup)
        {
            var entity = _db.userInterestGroups
                .FirstOrDefault(uig => uig.UserId == userInterestGroup.UserId &&
                                      uig.InterestGroupID == userInterestGroup.InterestGroupID);

            if (entity != null)
            {
                _db.userInterestGroups.Remove(entity);
                _db.SaveChanges();
            }
        }

        public List<UserInterestGroup> GetUserGroups(long userId)
        {
            return _db.userInterestGroups
                .Include(uig => uig.InterestGroup)
                .Where(uig => uig.UserId == userId)
                .ToList();
        }

        public List<UserInterestGroup> GetGroupUsers(long groupId)
        {
            return _db.userInterestGroups
                .Include(uig => uig.User)
                    .ThenInclude(u => u.Profile)
                .Include(uig => uig.User.Role)
                .Where(uig => uig.InterestGroupID == groupId)
                .ToList();
        }
    }
}
