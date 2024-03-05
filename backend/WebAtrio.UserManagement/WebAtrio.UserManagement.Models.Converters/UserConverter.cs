using WebAtrio.UserManagement.Models.DTO;
using WebAtrio.UserManagement.Models.Entities;

namespace WebAtrio.UserManagement.Models.Converters
{
    public class UserConverter
    {
        public static UserEntity ConvertToUser(UserDto userDto)
        {
            return new UserEntity
            {
                Id = userDto.Id,
                Firstname = userDto.Firstname,
                Lastname = userDto.Lastname,
                Email = userDto.Email,
                CreatedAt = userDto.CreatedAt,
                UpdatedAt = userDto.UpdatedAt
            };
        }

        public static UserDto ConvertToUserDto(UserEntity user)
        {
            return new UserDto
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }
    }
}
