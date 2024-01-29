using Development.Assesment.Data.Context;
using Development.Assesment.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Development.Assesment.Data.Operations
{
    public class GroupOperations : IOperations, IGroupOperations
    {
        private readonly AssesmentContext _dbContext;

        public GroupOperations(AssesmentContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Create(string body)
        {
            _dbContext.Groups.Add(JsonConvert.DeserializeObject<Group>(body));
            return _dbContext.SaveChanges() != 0;
        }

        public bool Delete(string body)
        {
            Group Group = JsonConvert.DeserializeObject<Group>(body);
            Group GroupToDelete = _dbContext.Groups.FirstOrDefault(g => g.GroupId == Group.GroupId);
            if (GroupToDelete != null)
            {
                _dbContext.Groups.Remove(GroupToDelete);
                return _dbContext.SaveChanges() != 0;
            }
            else
                return true;
        }

        public object Read(int? id = null)
        {
            if (id == null)
                return _dbContext.Groups.Include(g=> g.Permissions).ToList();
            else
                return _dbContext.Groups
            .Include(g => g.Users)
            .Include(g => g.Permissions)
            .Where(g => g.GroupId == id)
            .Select(g => new Group { GroupId = g.GroupId, GroupName = g.GroupName, GroupDescription = g.GroupDescription }).ToList();

        }

        public bool Update(object body)
        {
            Group Group = JsonConvert.DeserializeObject<Group>(body.ToString());
            Group GroupToUpdate = _dbContext.Groups.FirstOrDefault(u => u.GroupId == Group.GroupId);
            if (GroupToUpdate != null)
            {
                GroupToUpdate = Group;
                return _dbContext.SaveChanges() != 0;
            }
            else
                return true;
        }
    }
}
