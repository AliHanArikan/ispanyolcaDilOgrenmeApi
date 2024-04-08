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
    }
}
