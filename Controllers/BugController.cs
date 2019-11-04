using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using MadBugAPI.Controllers.Dtos;
using MadBugAPI.Data;
using MadBugAPI.Data.Entities;
using MadBugAPI.Data.Repositories;
using MadBugAPI.Infrastructure.ManagedResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MadBugAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    [ProducesResponseType(401, Type = typeof(string))]
    [Authorize]
    public class BugController : ControllerBase
    {
        /// <summary>
        /// Mapping between objects
        /// </summary>
        private IMapper _mapper;
        /// <summary>
        /// Repository of bug entities
        /// </summary>
        private BugRepository _bugRepository;
        /// <summary>
        /// Data context
        /// </summary>
        private MadBugContext _context;
        
        public BugController(BugRepository bugRepository, MadBugContext context, IMapper mapper)
        {
            _bugRepository = bugRepository;
            _context = context;
            _mapper = mapper;
        }


        private string CurrentUserId(ClaimsPrincipal claims){
                return claims.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] BugRegisterDto model){ //Dto

            //Model validation
            if(!ModelState.IsValid){
               return BadRequest
               (new ManagedErrorResponse(ManagedErrorCode.Validation,
               "Hay errores de validación",
               ModelState));
            }
            try{
                //Model is valid
                //Mapping object to Entity
                var bug = _mapper.Map<Bug>(model);
                //Send to save
                bug.UserId = CurrentUserId(User as ClaimsPrincipal);
                bug.CreatedAt = DateTime.Now;
                //oops, where is the userId
                _bugRepository.Insert(bug);
                _context.SaveChanges();
                //Convert to model for response
                var bugToResponse = _mapper.Map<BugResponseDto>(bug);
                return Ok(bugToResponse);
            }
            catch(Exception ex){
                var errorResponse = 
                new ManagedErrorResponse(ManagedErrorCode.Exception,"hay errores",ex);
                return BadRequest(errorResponse);
            }
        }
        
        [HttpGet]
        public IActionResult Get(){
            var bugs = _bugRepository.GetAll();
            var bugsDtos = _mapper.Map<List<BugResponseDto>>(bugs);
            return Ok(bugsDtos);
        }

        [HttpGet("user/{userId}")]
        public IActionResult Get(string userId){
            var bugs = _bugRepository.GetByUserId(userId);
            var bugsDtos = _mapper.Map<List<BugResponseDto>>(bugs);
            return Ok(bugsDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var bug = _bugRepository.GetById(id);

            if(bug == null)
                return NotFound();
            var bugDto = _mapper.Map<BugResponseDto>(bug);
            return Ok(bugDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            _bugRepository.Delete(id);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BugUpdateDto model){
            //Model validation
            if(!ModelState.IsValid){
               return BadRequest
               (new ManagedErrorResponse(ManagedErrorCode.Validation,
               "Hay errores de validación",
               ModelState));
            }
            var bug = _mapper.Map<Bug>(model);
            bug.ModifiedAt = DateTime.Now;
            bug.ModifiedById =  CurrentUserId(User as ClaimsPrincipal);
            _bugRepository.Update(bug);
            _context.SaveChanges();
            var dto = _mapper.Map<BugResponseDto>(bug);
            return Ok(dto);
        }

       


    }
}
