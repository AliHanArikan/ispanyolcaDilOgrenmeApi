using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpanishTopicController : Controller
    {
      private readonly ISpanishTopicService _spanishTopicService;

        public SpanishTopicController(ISpanishTopicService spanishTopicService)
        {
            _spanishTopicService = spanishTopicService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _spanishTopicService.TGetAllAsync(); 
            return Ok(values);
        }
    }
}
