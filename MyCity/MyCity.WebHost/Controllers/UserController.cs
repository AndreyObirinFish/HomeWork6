using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyCity.Core.Abstractions.Services;
using MyCity.WebHost.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Dtos.UserDtos;

namespace MyCity.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetAllAsync()
        {
            return Ok(_mapper.Map<List<UserResponse>>(await _userService.GetAllAsync()));
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<UserResponse>> GetAsync(Guid id)
        {
            var result = await _userService.GetAsync(id);
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<UserResponse>(result));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync(CreateOrUpdateUserRequest user)
        {
            var result = await _userService.CreateAsync(_mapper.Map<CreateOrUpdateUserDto>(user));
            return Ok(result);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateAsync(Guid id, CreateOrUpdateUserRequest user)
        {
            var result = await _userService.UpdateAsync(id, _mapper.Map<CreateOrUpdateUserDto>(user));
            if (result)
                return Ok();
            return NotFound();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var result = await _userService.DeleteAsync(id);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}
