using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCity.Core.Abstractions.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyCity.Dtos.ReviewDto;
using MyCity.WebHost.Models;

namespace MyCity.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public ReviewController(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReviewResponse>>> GetAllAsync()
        {
            return Ok(_mapper.Map<List<ReviewResponse>>(await _reviewService.GetAllAsync()));
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ReviewResponse>> GetAsync(Guid id)
        {
            var result = await _reviewService.GetAsync(id);
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<ReviewResponse>(result));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync(CreateOrUpdateReviewRequest review)
        {
            var result = await _reviewService.CreateAsync(_mapper.Map<CreateOrUpdateReviewDto>(review));
            return Ok(result);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateAsync(Guid id, CreateOrUpdateReviewRequest review)
        {
            var result = await _reviewService.UpdateAsync(id, _mapper.Map<CreateOrUpdateReviewDto>(review));
            if (result)
                return Ok();
            return NotFound();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var result = await _reviewService.DeleteAsync(id);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}
