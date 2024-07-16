using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCity.Core.Abstractions.Services;
using MyCity.Dtos.PointOfInterestDtos;
using MyCity.WebHost.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MyCity.Dtos.MediaFileDtos;

namespace MyCity.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPointOfInterestService _pointService;

        public PointOfInterestController(IPointOfInterestService pointService, IMapper mapper)
        {
            _mapper = mapper;
            _pointService = pointService;
        }


        [HttpGet]
        public async Task<ActionResult<List<PointOfInteresetResponse>>> GetAllAsync()
        {
            return Ok(_mapper.Map<List<PointOfInteresetResponse>>(await _pointService.GetAllAsync()));
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<PointOfInteresetResponse>> GetAsync(Guid id)
        {
            var result = await _pointService.GetAsync(id);
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<PointOfInteresetResponse>(result));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync(CreateOrUpdatePointOfInterestDto pointService)
        {
            var result = await _pointService.CreateAsync(_mapper.Map<CreateOrUpdatePointOfInterestDto>(pointService));
            return Ok(result);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateAsync(Guid id, CreateOrUpdatePointOfInterestDto pointService)
        {
            var result = await _pointService.UpdateAsync(id, _mapper.Map<CreateOrUpdatePointOfInterestDto>(pointService));
            if (result)
                return Ok();
            return NotFound();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var result = await _pointService.DeleteAsync(id);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}
