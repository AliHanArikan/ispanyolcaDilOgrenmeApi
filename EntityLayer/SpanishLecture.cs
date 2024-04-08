﻿using System;
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
        public string SpanishLectureTopicName { get; set; }
        public string SpanishLectureTopicImage { get; set; }
        public string SpanishLectureContents1 { get; set; }

        public string SpanishLectureContents2 { get; set; }

        public string SpanishLectureIsActive { get; set; }

        public ICollection<SpanishExam> SpanishExam { get; set;}

        public ICollection<SpanishShortDescription> SpanishShortDescriptions { get; set; }
    }
}
