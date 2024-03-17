using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class SpanishSubTopic
    {
        public int SpanishSubTopicId { get; set; }
        public int SpanishTopicId { get; set; } // Foreign key property

        public SpanishTopic SpanishTopic { get; set; }

        public string TopicName { get; set; }
        public string? SubTopicDescription { get; set; }
        public string? SubTopicDescription2 { get; set; }
        public string? SubTopicPhoto { get; set; }
    }
}
