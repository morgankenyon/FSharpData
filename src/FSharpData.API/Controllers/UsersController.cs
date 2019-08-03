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
        // GET api/questions
        [Produces("application/json")]
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await userRepo.GetUsers();
        }

        // GET api/questions/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await userRepo.GetUser(id);
        }

        // POST api/questions
        [HttpPost]
        public async Task<User> Post(User question)
        {
            return await userRepo.CreateUser(question);
        }
    }
}