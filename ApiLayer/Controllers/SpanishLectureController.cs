using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using DtoLayer.Dtos.SpanishLectureDtos;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpanishLectureController : Controller
    {
        private readonly ISpanishLectureService _spanishLectureService;
        private readonly IMapper _mapper;
        public SpanishLectureController(ISpanishLectureService spanishLectureService, IMapper mapper)
        {
            _spanishLectureService = spanishLectureService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpanishLecture()
        {
            var values= await _spanishLectureService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdSpanishLecture(int id)
        {
            var value = await _spanishLectureService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsyncSpanishLecture(AddSpanishLectureDto addSpanishLectureDto)
        {

            var validator = new AddSpanishLectureValidator();
            var validationResult = validator.Validate(addSpanishLectureDto);

            if(!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error  => error.ErrorMessage).ToList();
                return BadRequest(errors);
            }


            var spanishLecture = _mapper.Map<SpanishLecture>(addSpanishLectureDto);
            await _spanishLectureService.TAddAsync(spanishLecture);
            return Ok("Added new Lecture");
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsyncSpanishLecture(int id)
        {
            try
            {
                var spanishLecture = await _spanishLectureService.TGetByIdAsync(id);
                await _spanishLectureService.TDeleteAsync(spanishLecture);
                return Ok("Entity deleted successfully");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        

            
        }

      
    }
}
