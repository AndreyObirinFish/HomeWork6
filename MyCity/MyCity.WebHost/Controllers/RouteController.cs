using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCity.Core.Abstractions.Services;
using MyCity.Dtos.CustomStopDtos;
using MyCity.WebHost.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MyCity.Dtos.RouteDtos;

namespace MyCity.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;
        private readonly IMapper _mapper;

        public RouteController(IRouteService routeService, IMapper mapper)
        {
            _routeService = routeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<RouteResponse>>> GetAllAsync()
        {
            return Ok(_mapper.Map<List<RouteResponse>>(await _routeService.GetAllAsync()));
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<RouteResponse>> GetAsync(Guid id)
        {
            var result = await _routeService.GetAsync(id);
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<RouteResponse>(result));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync(CreateOrUpdateRouteDto routeService)
        {
            var result = await _routeService.CreateAsync(_mapper.Map<CreateOrUpdateRouteDto>(routeService));
            return Ok(result);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateAsync(Guid id, CreateOrUpdateRouteDto routeService)
        {
            var result = await _routeService.UpdateAsync(id, _mapper.Map<CreateOrUpdateRouteDto>(routeService));
            if (result)
                return Ok();
            return NotFound();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var result = await _routeService.DeleteAsync(id);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}
