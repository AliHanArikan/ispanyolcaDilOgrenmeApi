using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.SpanishExamDtos
{
    public class AddSpanishExamDto
    {
        public int SpanishExamId { get; set; }

        public int SpanishLectureId { get; set; } // foreign key

       // public SpanishLecture SpanishLecture { get; set; }

        public string SpanishExamDescription { get; set; }

        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string CorrectAnswer { get; set; }

        public int QuestionLevel { get; set; }
    }
}
