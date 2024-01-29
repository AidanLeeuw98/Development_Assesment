using Development.Assesment.Data.Context;
using Development.Assesment.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Development.Assesment.Data.Operations
{
    public class UserOperations : IOperations, IUserOperations
    {
        private readonly AssesmentContext _dbContext;

        public UserOperations(AssesmentContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Create(string body)
        {
            _dbContext.Users.Add(JsonConvert.DeserializeObject<User>(body));
            return _dbContext.SaveChanges() != 0;
        }

        public bool Delete(string body)
        {
            User user = JsonConvert.DeserializeObject<User>(body);
            User userToDelete = _dbContext.Users.FirstOrDefault(u => u.UserId == user.UserId);
            if (userToDelete != null)
            {
                _dbContext.Users.Remove(userToDelete);
                return _dbContext.SaveChanges() != 0;
            }
            else
                return true;
        }

        public object Read(int? id = null)
        {
            if (id == null)
                return _dbContext.Users.Include(u => u.Groups).ToList();
            else
                return _dbContext.Users
            .Include(u => u.Groups)
            .Where(u => u.UserId == id)
            .Select(u => new User { UserId = u.UserId, UserName = u.UserName }).ToList();

        }

        public bool Update(object body)
        {
            User user = JsonConvert.DeserializeObject<User>(body.ToString());
            User userToUpdate = _dbContext.Users.FirstOrDefault(u => u.UserId == user.UserId);
            if (userToUpdate != null)
            {
                userToUpdate = user;
                return _dbContext.SaveChanges() != 0;
            }
            else
                return true;
        }
    }
}
