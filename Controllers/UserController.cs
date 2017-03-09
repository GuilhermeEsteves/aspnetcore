using System.Collections.Generic;
using AchadosPerdidosApi.Repository.Infra.Entities;
using AchadosPerdidosApi.Repository.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AchadosPerdidosApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        public IEnumerable<User> Get()
        {
            using (var userRepository = new UserRepository())
                return userRepository.Get();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            using (var userRepository = new UserRepository())
                return userRepository.Get(id);
        }

        [HttpPost]
        public User Post([FromBody]User user)
        {
            using (var userRepository = new UserRepository())
                return userRepository.Add(user);
        }

        [HttpPut("{id}")]
        public User Put(int id, [FromBody]User user)
        {
            user.Id = id;

            using (var userRepository = new UserRepository())
                return userRepository.Update(user);
        }

        [HttpDelete("{id}")]
        public User Delete(int id)
        {
            using (var userRepository = new UserRepository())
                return userRepository.Remove(id);
        }
    }
}
