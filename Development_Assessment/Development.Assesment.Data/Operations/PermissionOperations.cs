using Development.Assesment.Data.Context;
using Development.Assesment.Data.Interfaces;
using Newtonsoft.Json;

namespace Development.Assesment.Data.Operations
{
    public class PermissionOperations : IOperations, IPermissionOperations
    {
        private readonly AssesmentContext _dbContext;

        public PermissionOperations(AssesmentContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(string body)
        {
            _dbContext.Permissions.Add(JsonConvert.DeserializeObject<Permission>(body));
            return _dbContext.SaveChanges() != 0;
        }

        public bool Delete(string body)
        {
            Permission Permission = JsonConvert.DeserializeObject<Permission>(body);
            Permission PermissionToDelete = _dbContext.Permissions.FirstOrDefault(p => p.PermissionId == Permission.PermissionId);
            if (PermissionToDelete != null)
            {
                _dbContext.Permissions.Remove(PermissionToDelete);
                return _dbContext.SaveChanges() != 0;
            } 
            else
                return true;
        }

        public object Read(int? id = null)
        {
            if (id == null)
                return _dbContext.Permissions.ToList();
            else
                return _dbContext.Permissions
            .Where(p => p.PermissionId == id)
            .Select(p => new Permission { PermissionId = p.PermissionId, PermissionName = p.PermissionName, PermissionDescription = p.PermissionDescription }).ToList();

        }

        public bool Update(object body)
        {
            Permission Permission = JsonConvert.DeserializeObject<Permission>(body.ToString());
            Permission PermissionToUpdate = _dbContext.Permissions.FirstOrDefault(p => p.PermissionId == Permission.PermissionId);
            if (PermissionToUpdate != null)
            {
                PermissionToUpdate = Permission;
                return _dbContext.SaveChanges() != 0;
            }
            else
                return true;
        }
    }
}
