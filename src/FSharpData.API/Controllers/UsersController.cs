using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSharpData.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FSharpData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository userRepo;

        public UsersController(IUserRepository userRepository)
        {
            userRepo = userRepository;
        }
        // GET api/users
        [Produces("application/json")]
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await userRepo.GetUsers();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await userRepo.GetUser(id);
        }

        // POST api/users
        [HttpPost]
        public async Task<User> Post(User user)
        {
            return await userRepo.CreateUser(user);
        }
    }
}