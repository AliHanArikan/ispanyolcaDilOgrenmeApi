using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation.SpanishExam;
using DtoLayer.Dtos.SpanishExamDtos;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName= "10mins")]

    public class SpanishExamController : ControllerBase
    {
        private readonly ISpanishExamService _spanishExamService;
        private readonly IMapper _mapper;
        public SpanishExamController(ISpanishExamService spanishExamService, IMapper mapper)
        {
            _spanishExamService = spanishExamService;
            _mapper = mapper;
        }

        [HttpGet("GetAsyncSpanishExam")]
        [ResponseCache(Duration = 60)]//Sunucu üzerinden
        public async Task<IActionResult> GetAsyncSpanishExam()
        {
            var values = await _spanishExamService.TGetAllAsync();
            return Ok(values);
        }

        [HttpPost("AddAsyncSpanishExam")]
        public async Task<IActionResult> AddAsyncSpanishExam(AddSpanishExamDto addSpanishExamDto)
        {
            try
            {
                var validator = new AddSpanishExamValidator();
                var validationResult = validator.Validate(addSpanishExamDto);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                    return BadRequest(new { errors });
                }

                var spanishExam = _mapper.Map<SpanishExam>(addSpanishExamDto);
                await _spanishExamService.TAddAsync(spanishExam);

                return Ok("Başarıyla Eklendi");
            }catch (Exception ex)
            { 
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeleteAsyncSpanishExam")]
        
        public async Task<IActionResult> DeleteAsyncSpanishExam(int id) 
        {
            try
            {
                var spanishExam = await _spanishExamService.TGetByIdAsync(id);
                await _spanishExamService.TDeleteAsync(spanishExam);
                return Ok("Başarıyla Silindi");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateAsyncSpanishExam")]
        public async Task<IActionResult> UpdateAsyncSpanishExam(int id,UpdateSpanishExamDto updateSpanishExamDto)
        {
            try
            {
                var spanishExam = await _spanishExamService.TGetByIdAsync(id);

                spanishExam.SpanishLectureId = updateSpanishExamDto.SpanishLectureId;
                spanishExam.SpanishExamDescription = updateSpanishExamDto.SpanishExamDescription;
                spanishExam.OptionA = updateSpanishExamDto.OptionA;
                spanishExam.OptionB = updateSpanishExamDto.OptionB;
                spanishExam.OptionC = updateSpanishExamDto.OptionC;
                spanishExam.OptionD = updateSpanishExamDto.OptionD;
                spanishExam.CorrectAnswer = updateSpanishExamDto.CorrectAnswer;
                spanishExam.QuestionLevel = updateSpanishExamDto.QuestionLevel;

                await _spanishExamService.TUpdateAsync(spanishExam);
                return Ok("Başarıyla Güncellendi");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByIdSpanishExam")]
        public async Task<IActionResult> GetByIdSpanishExam(int id)
        {
            var value = await _spanishExamService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("GetSpanishExamWithLectureId")]
        public async Task<IActionResult> GetSpanishExamWithLectureId(int LectureId)
        {
            var value = await _spanishExamService.TGetSpanishExamWithLectureId(LectureId);
            return Ok(value);
        }
    }
}
