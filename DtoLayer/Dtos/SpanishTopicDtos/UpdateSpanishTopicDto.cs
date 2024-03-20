using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.SpanishTopicDtos
{
    public class UpdateSpanishTopicDto
    {
        public int SpanishTopicId { get; set; }

        public string SpanishTopicName { get; set; }
        public string? TopicDescription { get; set; }
        public string? TopicPhoto { get; set; }
        public int LessonLevel { get; set; }

        public bool IsActive { get; set; }
    }
}
