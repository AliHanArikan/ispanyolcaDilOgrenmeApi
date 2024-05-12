using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.SpanishShortDescriptionDtos
{
    public class AddSpanishShortDescriptionDto
    {
        public int SpanishShortDescriptionId { get; set; }
        public int SpanishLectureId { get; set; } // foreign key

        public SpanishLecture SpanishLecture { get; set; }

        public string ShortDescriptionPhoto { get; set; }

        public string ShortDescriptionText { get; set; }
    }
}
