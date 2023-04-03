using assignment1.Common.Dto;
using assignment1.Common.Model;
using assignment1.DAL.UserDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace assignment1.Business
{
    public class UserManager : IUserManager
    {
        private readonly UserDbContext _context;
        private readonly IServiceProvider serviceProvider;


        public UserManager(UserDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            this.serviceProvider = serviceProvider;
        }


        public async Task<List<UserDto>> GetUsers()
        {
            var context = serviceProvider.GetRequiredService<UserDbContext>();
            var listOfUsers = await context.Users.ToListAsync();
            List<UserDto> users = new List<UserDto>();
            foreach (var user in listOfUsers)
            {
                users.Add(new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                });
            }
            return users;
        }

        public async Task<(bool, string)> AddUser(UserDto userDto)
        {
            var context = serviceProvider.GetRequiredService<UserDbContext>();
            var existingUsers = context.Users.AsQueryable();
            IEnumerable<User> duplicates = from person in existingUsers
                                           where person.Email == userDto.Email
                                           && person.FirstName == userDto.FirstName && person.LastName == userDto.LastName
                                           select person;
            if (duplicates.Any())
            {
                return (false, "User already exists! ");
            }
            User user = new User
            {
                Id = userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
            };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return (true, "User Added ! ");
        }

        public async Task<(bool, string)> UpdateUser(UserDto userdto)
        {
            var context = serviceProvider.GetRequiredService<UserDbContext>();
            var existingUser = await context.Users.FindAsync(userdto.Id);

            var audited = existingUser;

            if (existingUser != null)
            {

                existingUser.Email = userdto.Email;
                existingUser.FirstName = userdto.FirstName;
                existingUser.LastName = userdto.LastName;

                await context.SaveChangesAsync();
                return (true, $"User updated {audited.FirstName} {audited.LastName}  {audited.Email} ");
            }
            return (false, "User not found with id " + userdto.Id);
        }

        public async Task<(bool,string)> DeleteUser(int id)
        {
            var context = serviceProvider.GetRequiredService<UserDbContext>();
            var existingUser = await context.Users.FindAsync(id);

            if (existingUser != null)
            {
                context.Users.Remove(existingUser);
                await context.SaveChangesAsync();
                return (true, $"User deleted {existingUser.FirstName} --- {existingUser.LastName} --- {existingUser.Email} ");
            }
            return (false, "User not found! invalid ID");
        }

       
    }
}
