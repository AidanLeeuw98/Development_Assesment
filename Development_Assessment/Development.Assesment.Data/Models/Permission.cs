using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Development.Assesment.Data
{
    [Table(name: "Permission")]
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }
        [Required]
        public string PermissionName { get; set; }
        public string PermissionDescription { get; set; }
        [JsonIgnore]
        public virtual ICollection<Group> Groups { get; set; }
    }
}
