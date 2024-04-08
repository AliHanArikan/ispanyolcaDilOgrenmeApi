using DtoLayer.Dtos.SpanishExamDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation.SpanishExam
{
    public class AddSpanishExamValidator : AbstractValidator<AddSpanishExamDto>
    {
        public AddSpanishExamValidator()
        {
          

            RuleFor(e => e.SpanishExamDescription)
                .NotEmpty().WithMessage("İspanyolca sınav açıklaması boş olamaz.")
                .MaximumLength(1000).WithMessage("İspanyolca sınav açıklaması en fazla 1000 karakter olmalıdır.");

            RuleFor(e => e.OptionA)
                .NotEmpty().WithMessage("Seçenek A boş olamaz.")
                .MaximumLength(500).WithMessage("Seçenek A en fazla 500 karakter olmalıdır.");

            RuleFor(e => e.OptionB)
                .NotEmpty().WithMessage("Seçenek B boş olamaz.")
                .MaximumLength(500).WithMessage("Seçenek B en fazla 500 karakter olmalıdır.");

            RuleFor(e => e.OptionC)
                .NotEmpty().WithMessage("Seçenek C boş olamaz.")
                .MaximumLength(500).WithMessage("Seçenek C en fazla 500 karakter olmalıdır.");

            RuleFor(e => e.OptionD)
                .NotEmpty().WithMessage("Seçenek D boş olamaz.")
                .MaximumLength(500).WithMessage("Seçenek D en fazla 500 karakter olmalıdır.");

            RuleFor(e => e.CorrectAnswer)
                .NotEmpty().WithMessage("Doğru cevap boş olamaz.");
               // .Must(BeValidAnswer).WithMessage("Doğru cevap A, B, C veya D olmalıdır.");

            RuleFor(e => e.QuestionLevel)
                .InclusiveBetween(1, 5).WithMessage("Soru seviyesi 1 ile 5 arasında olmalıdır.");
        }

        // Doğru cevap kontrolü için yardımcı metot
        //private bool BeValidAnswer(string answer)
        //{
        //    return answer == "A" || answer == "B" || answer == "C" || answer == "D";
        //}
    }
}
