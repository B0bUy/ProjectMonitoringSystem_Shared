using PMS_Serverv1.Entities.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS_Serverv1.Entities.UserManagement
{
    public class Access : BaseEntity
    {
        [Key]
        public Guid AccessId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
    }
    public class UserAccess : BaseEntity
    {
        [Key]
        public Guid UserAccessId { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; } = Guid.Empty;
        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid AccessId { get; set; } = Guid.Empty;
        [ForeignKey("AccessId")]
        public Access Access { get; set; }
    }
}
