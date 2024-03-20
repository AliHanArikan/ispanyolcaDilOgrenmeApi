using DtoLayer.Dtos.SpanishTopicDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation.SpanishTopic
{
    public class UpdateSpanishTopicValidator : AbstractValidator<UpdateSpanishTopicDto>
    {
        public UpdateSpanishTopicValidator()
        {

            RuleFor(dto => dto.SpanishTopicName)
                .NotEmpty().WithMessage("İspanyolca konu adı boş olamaz.")
                .MinimumLength(5).WithMessage("Konu Adı En Az 5 Karakter Olmalıdır")
                .MaximumLength(100).WithMessage("İspanyolca konu adı en fazla 100 karakter olmalıdır.");

            RuleFor(dto => dto.TopicDescription)
                .MaximumLength(500).WithMessage("Konu açıklaması en fazla 500 karakter olmalıdır.");

            RuleFor(dto => dto.TopicPhoto)
                .MaximumLength(100).WithMessage("Konu fotoğrafı en fazla 100 karakter olmalıdır.");

            RuleFor(dto => dto.LessonLevel)
                .NotEmpty().WithMessage("Ders seviyesi belirtilmelidir.")
                .InclusiveBetween(1, 5).WithMessage("Ders seviyesi 1 ile 5 arasında olmalıdır.");

            RuleFor(dto => dto.IsActive)
                .NotNull().WithMessage("Aktiflik durumu belirtilmelidir.");
        }
    }
}
