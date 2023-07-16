using System.Collections.Generic;
using Gifter.Models;
using Gifter.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Gifter.Controllers
{
    [Route("api/userprofiles")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userRepository;
        private readonly IPostRepository _postRepository;
        public UserProfileController(IUserProfileRepository userRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        // GET: api/userprofiles
        [HttpGet]
        public IActionResult GetAll()
        {
            var userProfiles = _userRepository.GetAll();
            return Ok(userProfiles);
        }

        // GET: api/userprofiles/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var userProfile = _userRepository.GetById(id);
            if (userProfile == null)
            {
                return NotFound();
            }
            return Ok(userProfile);
        }

        // POST: api/userprofiles
        [HttpPost]
        public IActionResult Create(UserProfile userProfile)
        {
            _userRepository.Add(userProfile);
            return CreatedAtAction(nameof(GetById), new { id = userProfile.Id }, userProfile);
        }

        // PUT: api/userprofiles/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, UserProfile userProfile)
        {
            if (id != userProfile.Id)
            {
                return BadRequest();
            }
            _userRepository.Update(userProfile);
            return NoContent();
        }

        // DELETE: api/userprofiles/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userRepository.Delete(id);
            return NoContent();
        }

        [HttpGet("GetByIdWithPosts/{id}")]
        public IActionResult GetByIdWithPosts(int id)
        {
            var user = _userRepository.GetByIdWithPosts(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
