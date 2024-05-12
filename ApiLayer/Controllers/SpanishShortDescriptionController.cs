using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.SpanishShortDescriptionDtos;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpanishShortDescriptionController : ControllerBase
    {
        private readonly ISpanishShortDescriptionService _spanishShortDescriptionService;
        private readonly IMapper _mapper;

        public SpanishShortDescriptionController(ISpanishShortDescriptionService spanishShortDescriptionService, IMapper mapper)
        {
            _spanishShortDescriptionService = spanishShortDescriptionService;
            _mapper = mapper;
        }

        [HttpGet("GetShortDescriptionWithTopicId")]
        public async Task<IActionResult> GetShortDescriptionWithTopicId(int id)
        {
            var values= await _spanishShortDescriptionService.TGetSpanishShortDescriptionWitTopicId(id);
            return Ok(values);
        }

        [HttpDelete("DeleteShortDescription")]
        public async Task<IActionResult> DeleteShortDescription(int id)
        {
            var values = await _spanishShortDescriptionService.TGetByIdAsync(id);
            await _spanishShortDescriptionService.TDeleteAsync(values);
            return Ok(values);
        }

        public async Task<IActionResult> AddShortDescription(AddSpanishShortDescriptionDto addSpanishShortDescriptionDto)
        {
            // var spanishExam = _mapper.Map<SpanishExam>(addSpanishExamDto);
            var spanishShortDescription = _mapper.Map<SpanishShortDescription>(addSpanishShortDescriptionDto);
           await _spanishShortDescriptionService.TAddAsync(spanishShortDescription);
            return Ok("Başarıyla eklendi");
        }

        
    }
}
