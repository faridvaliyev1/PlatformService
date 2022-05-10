using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController:ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repository,IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting platforms --");

            var platformItems=_repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }

        [HttpGet("{Id}",Name="GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int Id)
        {
            Console.WriteLine("--> Getting platform");

            var platformitem=_repository.GetPlatformById(Id);

            if(platformitem!=null)
                return Ok(_mapper.Map<PlatformReadDto>(platformitem));
            
            return NotFound();
        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            var model=_mapper.Map<Platform>(platformCreateDto);
            _repository.CreatePlatform(model);
            _repository.SaveChanges();

            var platformReadDto=_mapper.Map<PlatformReadDto>(model);
            
            return CreatedAtRoute(nameof(GetPlatformById),new {Id=platformReadDto.Id},platformReadDto);
        }
    }
}