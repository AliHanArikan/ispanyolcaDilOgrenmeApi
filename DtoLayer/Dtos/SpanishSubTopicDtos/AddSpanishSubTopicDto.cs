using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.SpanishSubTopicDtos
{
    public class AddSpanishSubTopicDto
    {
        public int SpanishSubTopicId { get; set; }
        public int SpanishTopicId { get; set; } // Foreign key property

        public string TopicName { get; set; }
        public string? SubTopicDescription { get; set; }
        public string? SubTopicDescription2 { get; set; }
        public string? SubTopicPhoto { get; set; }
    }
}
