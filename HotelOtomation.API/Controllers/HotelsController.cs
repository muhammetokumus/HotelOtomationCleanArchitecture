using HotelOtomation.Application.Repositories;
using HotelOtomation.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelOtomation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelReadRepository _readRepository;
        private readonly IHotelWriteRepository _writeRepository;

        public HotelsController(IHotelWriteRepository writeRepository, IHotelReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var hotels = _readRepository.GetAll();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _readRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Hotel hotel)
        {
            if (ModelState.IsValid && hotel != null)
            {
                await _writeRepository.AddAsync(hotel);
                await _writeRepository.SaveAsync();
                return Ok();
            }
            return BadRequest();
        }



        [HttpPut]
        public async Task<IActionResult> Put(Hotel hotel)
        {
            if (ModelState.IsValid && hotel != null)
            {
                _writeRepository.Update(hotel);
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
                var hotel = await _readRepository.GetByIdAsync(id);
                _writeRepository.Remove(hotel);
                await _writeRepository.SaveAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}
