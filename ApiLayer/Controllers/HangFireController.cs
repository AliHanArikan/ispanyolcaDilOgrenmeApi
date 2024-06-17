using BusinessLayer.Concrete;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    public class HangFireController : Controller
    {
       
        public IActionResult Get()
        {
            HangFireManager manager = new HangFireManager();

            BackgroundJob.Enqueue(() => manager.SpanishLessonReminder());

            return Ok();
        }
    }
}
