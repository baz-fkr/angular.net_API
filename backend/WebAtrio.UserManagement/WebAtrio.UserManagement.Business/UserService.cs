using Microsoft.Extensions.Logging;
using WebAtrio.UserManagement.Infrastructure;
using WebAtrio.UserManagement.Models.Converters;
using WebAtrio.UserManagement.Models.DTO;
using WebAtrio.UserManagement.Models.Entities;

namespace WebAtrio.UserManagement.Business
{
    public class UserService : IUserService
    {
        private ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;

        public UserService(ILogger<UserService> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<UserDto> AddUser(UserDto userDto)
        {
            UserEntity user = UserConverter.ConvertToUser(userDto);

            user = await _userRepository.Add(user);
            _logger.LogInformation($"User { user.Id } has been created in database.");

            return UserConverter.ConvertToUserDto(user);
        }

        public async Task<UserDto> GetUser(Guid id)
        {
            UserEntity user = await _userRepository.Get(id);

            if (user == null)
            {
                // TODO : handle null
                return null;
            }

            _logger.LogInformation($"User {user.Id} has been retrieved from database.");
            return UserConverter.ConvertToUserDto(user);
        }

        public async Task<List<UserDto>> GetUsers()
        {
            
            List<UserEntity> users = await _userRepository.GetAll();
            
            if(users != null && users.Count > 0)
            {
                _logger.LogInformation($"{ users.Count } users have been retrieved from database.");
                return users.Select(u => UserConverter.ConvertToUserDto(u)).ToList();
            }

            return new List<UserDto>();
        }

        public async Task<UserDto> UpdateUser(UserDto userDto)
        {
            UserEntity user = UserConverter.ConvertToUser(userDto);

            user = await _userRepository.Update(user);

            _logger.LogInformation($"User {user.Id} has been updated in database.");
            return UserConverter.ConvertToUserDto(user);
        }

        public async Task<UserDto> DeleteUser(Guid id)
        {
            UserEntity user = await _userRepository.Delete(id);

            if (user == null)
            {
                // TODO : handle null
                return null;
            }

            _logger.LogInformation($"User {user.Id} has been removed from database.");
            return UserConverter.ConvertToUserDto(user);
        }
    }
}
