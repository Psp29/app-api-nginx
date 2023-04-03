using assignment1.Common.Dto;
using assignment1.Common.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace assignment1.Business
{
    public interface IUserManager
    {
        Task<List<UserDto>> GetUsers();
        Task<(bool, string)> AddUser(UserDto userDto);
        Task<(bool, string)> UpdateUser(UserDto userdto);
        Task<(bool, string)> DeleteUser(int id);

    }
}
