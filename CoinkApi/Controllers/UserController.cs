using CoinkApi.DTOs;
using DataLayer.Entities;
using DomainLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoinkApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repo;        
        public UserController(IUserRepository repo)
        {            
            this.repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers(UserRequestQueryDto user)
        {
            var newUser = new User()
            {
                Id = user.Id == null ? 0 : (int)user.Id,
                Name = user.Name,
                Phone = user.Phone,
                Address = user.Address,
                CityId = user.CityId == null ? 0 : (int)user.CityId
            };
            var users = await repo.GetAll(newUser);
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserRequestAddDto user)
        {
            var newUser = new User()
            {
                Name = user.Name,
                Phone = user.Phone,
                Address = user.Address,
                CityId = user.CityId
            };
            var addedUser = await repo.Add(newUser);
            return Ok(addedUser);
        }
    }
}
