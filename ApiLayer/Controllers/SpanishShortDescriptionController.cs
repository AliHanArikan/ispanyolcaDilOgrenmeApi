using AutoMapper;
using BusinessLayer.Abstract;
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

        [HttpGet]
       // [SwaggerOperation(Summary = "Get Short Description With Topic ID", Description = "Retrieves short description with the specified topic ID.")]

        public async Task<IActionResult> GetShortDescriptionWithTopicId(int id)
        {
            var values= await _spanishShortDescriptionService.TGetSpanishShortDescriptionWitTopicId(id);
            return Ok(values);
        }
    }
}
