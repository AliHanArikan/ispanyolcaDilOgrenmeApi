using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpanishSubTopicController : Controller
    {
        private readonly ISpanishSubTopicService _spanishSubTopicService;

        public SpanishSubTopicController(ISpanishSubTopicService spanishSubTopicService)
        {
            _spanishSubTopicService = spanishSubTopicService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        { 
            var values = await  _spanishSubTopicService.TGetAllAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsyncSpanishSubTopic(SpanishSubTopic spanishSubTopic)
        {
            await _spanishSubTopicService.TAddAsync(spanishSubTopic);
            return Ok();
        }
    }
}
