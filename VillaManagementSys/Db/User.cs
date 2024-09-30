using System;
using System.Collections.Generic;

namespace VillaManagementSys.Db
{
    public partial class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Status { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
