using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyCity.Core.Abstractions.Services;
using MyCity.Dtos.MediaFileDtos;
using MyCity.WebHost.Models;

namespace MyCity.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaFileController : ControllerBase
    {
        private readonly IMediaFileService _mediaFileService;
        private readonly IMapper _mapper;

        public MediaFileController(IMediaFileService mediaFileService, IMapper mapper)
        {
            _mediaFileService = mediaFileService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MediaFileResponse>>> GetAllAsync()
        {
            return Ok(_mapper.Map<List<MediaFileResponse>>(await _mediaFileService.GetAllAsync()));
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<MediaFileResponse>> GetAsync(Guid id)
        {
            var result = await _mediaFileService.GetAsync(id);
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<MediaFileResponse>(result));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync(CreateOrUpdateMediaFileDto mediaFile)
        {
            var result = await _mediaFileService.CreateAsync(_mapper.Map<CreateOrUpdateMediaFileDto>(mediaFile));
            return Ok(result);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateAsync(Guid id, CreateOrUpdateMediaFileDto mediaFile)
        {
            var result = await _mediaFileService.UpdateAsync(id, _mapper.Map<CreateOrUpdateMediaFileDto>(mediaFile));
            if (result)
                return Ok();
            return NotFound();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var result = await _mediaFileService.DeleteAsync(id);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}
