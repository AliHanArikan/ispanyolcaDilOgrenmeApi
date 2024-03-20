using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class SpanishLecture
    {
        public int SpanishLectureId { get; set; }

        public int SpanishSubTopicId { get; set; }
        public SpanishSubTopic SpanishSubTopic { get; set; }  // Foreign key property
        public string SpanishSubTopicName { get; set; }
        public string SpanishSubTopicImage { get; set; }
        public string SpanishSubTopicContents1 { get; set; }

        public string SpanishSubTopicContents2 { get; set; }

        public string SpanishSubTopicIsActive { get; set; }
    }
}
