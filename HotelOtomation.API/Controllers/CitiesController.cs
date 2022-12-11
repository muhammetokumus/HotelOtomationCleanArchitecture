using HotelOtomation.Application.Repositories;
using HotelOtomation.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelOtomation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        ICityReadRepository _readRepository;
        ICityWriteRepository _writeRepository;

        public CitiesController(ICityWriteRepository writeRepository, ICityReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_readRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _readRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(City city)
        {
            if (ModelState.IsValid && city != null)
            {
                await _writeRepository.AddAsync(city);
                await _writeRepository.SaveAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(City city)
        {
            if (ModelState.IsValid && city != null)
            {
                _writeRepository.Update(city);
                await _writeRepository.SaveAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var city = await _readRepository.GetByIdAsync(id);
                _writeRepository.Remove(city);
                await _writeRepository.SaveAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}
