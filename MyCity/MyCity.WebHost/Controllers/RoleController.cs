using AutoMapper;
using Dtos.RoleDtos;
using Microsoft.AspNetCore.Mvc;
using MyCity.Core.Abstractions.Services;
using MyCity.WebHost.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCity.WebHost.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<RoleResponse>>> GetAllAsync()
        {
            return Ok(_mapper.Map<List<RoleResponse>>(await _roleService.GetAllAsync()));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync(CreateOrUpdateRoleRequest role)
        {
            var result = await _roleService.CreateAsync(_mapper.Map<CreateOrUpdateRoleDto>(role));
            return Ok(result);
        }
    }
}
