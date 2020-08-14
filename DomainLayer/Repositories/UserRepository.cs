using DataLayer.AccessDB;
using DataLayer.Entities;
using DomainLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> Add(User element)
        {
            int lastId = await UserAccessDataBase.AddUser(element);
            element.Id = lastId;

            return element;
        }

        public async Task<List<User>> GetAll(User element)
        {
            var users = await UserAccessDataBase.GetUsersAsync(new User());
            return users;
        }
    }
}
