using WebAtrio.UserManagement.Models.Entities;

namespace WebAtrio.UserManagement.Infrastructure
{
    public class UserRepository : BaseRepository<UserEntity, UMDbContext>, IUserRepository
    {
        public UserRepository(UMDbContext context) : base(context)
        {

        }
    }
}
