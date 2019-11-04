using System.Collections.Generic;
using AutoMapper;
using MadBugAPI.Controllers.Dtos;
using MadBugAPI.Data;
using MadBugAPI.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MadBugAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    [ProducesResponseType(401, Type = typeof(string))]
    [Authorize]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Mapping between objects
        /// </summary>
        private IMapper _mapper;
        /// <summary>
        /// Repository of bug entities
        /// </summary>
        private UserRepository _userRepository;
        /// <summary>
        /// Data context
        /// </summary>
        private MadBugContext _context;
        
        public UserController(UserRepository userRepository, MadBugContext context, IMapper mapper)
        {
            _userRepository = userRepository;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(){
            var users = _userRepository.GetAll();
            var bugsDtos = _mapper.Map<List<UserResponseDto>>(users);
            return Ok(bugsDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id){
            var user = _userRepository.GetById(id);
            if(user == null)
                return NotFound();
            var userDto = _mapper.Map<UserResponseDto>(user);
            return Ok(userDto);
        }

      

    }
}
