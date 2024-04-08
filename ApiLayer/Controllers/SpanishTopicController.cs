using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation.SpanishTopic;
using DataAccess.Abstract;
using DtoLayer.Dtos.SpanishTopicDtos;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpanishTopicController : Controller
    {
      private readonly ISpanishTopicService _spanishTopicService;
      private readonly IMapper _mapper;


        public SpanishTopicController(ISpanishTopicService spanishTopicService, IMapper mapper)
        {
            _spanishTopicService = spanishTopicService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var values = await _spanishTopicService.TGetAllAsync(); 
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsyncSpanishSubTopic(AddSpanishTopicDto addSpanishTopicDto)
        {
            // FluentValidation ile doğrulama yap
            var validator = new AddSpanishTopicValidatior();
            var validationResult = validator.Validate(addSpanishTopicDto);


            // Doğrulama hatası varsa
            if (!validationResult.IsValid)
            {
                // Hata mesajlarını topla
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();

                // HTTP 400 Bad Request yanıtı ile hataları döndür
                return BadRequest(new { errors });
            }

            // Doğrulama başarılı ise işlemi devam ettir
            // Örneğin, veritabanına kaydetme gibi...
            var spanishTopic = _mapper.Map<SpanishTopic>(addSpanishTopicDto);
            await _spanishTopicService.TAddAsync(spanishTopic);


            return Ok("Spanish topic successfully added.");

        }

        [HttpDelete]

        public async Task<IActionResult> DeleteSpanishTopic(int id)
        {
            var spanishTopic = await _spanishTopicService.TGetByIdAsync(id);
            await _spanishTopicService.TDeleteAsync(spanishTopic);
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateSpanishTopic(int id, [FromBody] UpdateSpanishTopicDto updateSpanishTopicDto)
        {
            var spanishTopic = await _spanishTopicService.TGetByIdAsync(id);


            if (spanishTopic == null)
            {
                return NotFound();
            }

            spanishTopic.SpanishTopicId = updateSpanishTopicDto.SpanishTopicId;
            spanishTopic.SpanishTopicName = updateSpanishTopicDto.SpanishTopicName;
            spanishTopic.TopicPhoto = updateSpanishTopicDto?.TopicPhoto;
            spanishTopic.TopicDescription = updateSpanishTopicDto?.TopicDescription;
            spanishTopic.IsActive = updateSpanishTopicDto.IsActive;
            spanishTopic.LessonLevel = updateSpanishTopicDto.LessonLevel;
            


            //spanishTopic = _mapper.Map<SpanishTopic>(updateSpanishTopicDto);
            _spanishTopicService.TUpdateAsync(spanishTopic);
            return Ok();

        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var value = await _spanishTopicService.TGetByIdAsync(id);
            return Ok(value);
        }
    }
}
