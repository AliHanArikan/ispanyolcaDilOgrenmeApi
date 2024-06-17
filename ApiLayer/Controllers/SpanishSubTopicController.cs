using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation.SpanishSubTopic;
using DtoLayer.Dtos.SpanishSubTopicDtos;
using DtoLayer.Dtos.SpanishTopicDtos;
using EntityLayer;
using EntityLayer.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using System.Text.Json;

namespace ApiLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpanishSubTopicController : Controller
    {
        private readonly ISpanishSubTopicService _spanishSubTopicService;
        private readonly IMapper _mapper;



        public SpanishSubTopicController(ISpanishSubTopicService spanishSubTopicService, IMapper mapper)
        {
            _spanishSubTopicService = spanishSubTopicService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        { 
            var values = await  _spanishSubTopicService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet("spanishSubTopicParameters")]
        public async Task<IActionResult> GetAllAsyncWithPAgination([FromQuery]SpanishSubTopicParameters spanishSubTopicParameters)
        {
            var values = await _spanishSubTopicService.TGetAllWithPagination(spanishSubTopicParameters);
            //Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(values.MetaData);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsyncSpanishSubTopic(AddSpanishSubTopicDto addSpanishSubTopicDto)
        {
            try
            {
                var validator = new AddSpanishSubTopicValidator();
                var validationResult = validator.Validate(addSpanishSubTopicDto);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                    return BadRequest(errors);
                }

                var spanishSubTopic = _mapper.Map<SpanishSubTopic>(addSpanishSubTopicDto);
                await _spanishSubTopicService.TAddAsync(spanishSubTopic);
                return Ok("Spanish topic successfully added.");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }


        [HttpDelete("DeleteSpanishSubTopic")]
        public async Task<IActionResult> DeleteSpanishSubTopic(int id)
        {
            var value = await _spanishSubTopicService.TGetByIdAsync(id);
            await _spanishSubTopicService.TDeleteAsync(value);
            return Ok("Basarıyla silindi");
        }

        [HttpPut("UpdateSpanishSubTopic")]
        public async Task<IActionResult> UpdateSpanishSubTopic(int id,UpdateSpanishSubTopicDto updateSpanishSubTopicDto)
        {
            try
            {
                var spanishSubTopic = await _spanishSubTopicService.TGetByIdAsync(id);

                if (spanishSubTopic == null)
                {
                    return NotFound();
                }

                //spanishSubTopic = _mapper.Map<SpanishSubTopic>(updateSpanishSubTopicDto);

                spanishSubTopic.SpanishSubTopicId = updateSpanishSubTopicDto.SpanishSubTopicId;
                spanishSubTopic.SpanishTopicId = updateSpanishSubTopicDto.SpanishTopicId;
                spanishSubTopic.TopicName = updateSpanishSubTopicDto.TopicName;
                spanishSubTopic.SubTopicPhoto = updateSpanishSubTopicDto.SubTopicPhoto;
                spanishSubTopic.SubTopicDescription = updateSpanishSubTopicDto?.SubTopicDescription;
                spanishSubTopic.SubTopicDescription2 = updateSpanishSubTopicDto?.SubTopicDescription2;
                

                await _spanishSubTopicService.TUpdateAsync(spanishSubTopic);
                return Ok("Başarılı");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetByIdSpanishSubTopic")]
        public async Task<IActionResult> GetByIdSpanishSubTopic(int id)
        {
            var spanishSubTopic=await _spanishSubTopicService.TGetByIdAsync(id);

            if (spanishSubTopic == null) {  return NotFound(); }

           
           // var spanishSubTopicDto = _mapper.Map<SpanishSubTopicDto>(spanishSubTopic);

            return Ok(spanishSubTopic);


        }

        [HttpGet("idTopic")]
         public async Task<IActionResult> GetSubTopicWithTopic(int idTopic)
        {
            var values = await _spanishSubTopicService.TGetSpanishSubTopicWithSpanishTopicId(idTopic);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }

        //[HttpGet("id")]
        //public async Task<IActionResult> GetSpanishSubTopicWithTopicId(int id)
        //{
        //    var values =await _spanishSubTopicService.TGetSpanishSubTopicWithSpanishTopicId(id);
        //    return Ok(values);
        //}
    }
}
