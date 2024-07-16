using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCity.Core.Abstractions.Services;
using MyCity.Dtos.MediaFileDtos;
using MyCity.WebHost.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MyCity.Dtos.CustomStopDtos;

namespace MyCity.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomStopController : ControllerBase
    {
        private readonly ICustomStopService _customStopService;
        private readonly IMapper _mapper;

        public CustomStopController(ICustomStopService customStopService, IMapper mapper)
        {
            _customStopService = customStopService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomStopResponse>>> GetAllAsync()
        {
            return Ok(_mapper.Map<List<CustomStopResponse>>(await _customStopService.GetAllAsync()));
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<CustomStopResponse>> GetAsync(Guid id)
        {
            var result = await _customStopService.GetAsync(id);
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<CustomStopResponse>(result));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync(CreateOrUpdateCustomStopDto customStopService)
        {
            var result = await _customStopService.CreateAsync(_mapper.Map<CreateOrUpdateCustomStopDto>(customStopService));
            return Ok(result);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateAsync(Guid id, CreateOrUpdateCustomStopDto customStopService)
        {
            var result = await _customStopService.UpdateAsync(id, _mapper.Map<CreateOrUpdateCustomStopDto>(customStopService));
            if (result)
                return Ok();
            return NotFound();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var result = await _customStopService.DeleteAsync(id);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}
