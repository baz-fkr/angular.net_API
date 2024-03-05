using WebAtrio.UserManagement.Models.DTO;

namespace WebAtrio.UserManagement.Business
{
    public interface IUserService
    {
        Task<UserDto> AddUser(UserDto userDto);

        Task<UserDto> GetUser(Guid id);

        Task<List<UserDto>> GetUsers();

        Task<UserDto> UpdateUser(UserDto userDto);

        Task<UserDto> DeleteUser(Guid id);
    }
}
