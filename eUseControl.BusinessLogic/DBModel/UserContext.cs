using System.Data.Entity;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.Admin;

namespace eUseControl.BusinessLogic.DbModel
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name = ProjectWeb")
        {
            /*Database.SetInitializer<UserContext>(null);*/
        }
        public virtual DbSet<SessionsDbTable> Sessions { get; set; }
        public virtual DbSet<UsersDbTable> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}
