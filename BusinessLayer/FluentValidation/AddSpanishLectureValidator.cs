using DtoLayer.Dtos.SpanishLectureDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class AddSpanishLectureValidator : AbstractValidator<AddSpanishLectureDto>
    {
        public AddSpanishLectureValidator()
        {
            RuleFor(dto => dto.SpanishLectureTopicName)
                .NotEmpty().WithMessage("İspanyolca ders konu adı boş olamaz.")
                .Length(3, 100).WithMessage("İspanyolca ders konu adı en az 3 ve en fazla 100 karakter uzunluğunda olmalıdır.")
                .Matches(@"^[a-zA-Z0-9\-_ ]+$").WithMessage("İspanyolca ders konu adı yalnızca harf, rakam, tire, alt çizgi ve boşluk içerebilir.");

            RuleFor(dto => dto.SpanishLectureTopicImage)
                .NotEmpty().WithMessage("İspanyolca ders konu fotoğrafı boş olamaz.")
                .MaximumLength(255).WithMessage("İspanyolca ders konu fotoğrafı en fazla 255 karakter olmalıdır.");
                //.Must(BeValidUrl).WithMessage("Geçerli bir URL formatı girilmelidir.");

            RuleFor(dto => dto.SpanishLectureContents1)
                .MaximumLength(5000).WithMessage("İspanyolca ders içeriği en fazla 5000 karakter olmalıdır.");

            RuleFor(dto => dto.SpanishLectureContents2)
                .MaximumLength(5000).WithMessage("İkinci İspanyolca ders içeriği en fazla 5000 karakter olmalıdır.");

            RuleFor(dto => dto.SpanishLectureIsActive)
                .Must(BeValidBoolean).WithMessage("İspanyolca ders aktiflik durumu geçerli bir boolean değeri olmalıdır.");

            RuleFor(dto => dto.SpanishSubTopicId)
                .InclusiveBetween(1, 1000).WithMessage("İspanyolca alt konu kimliği 1 ile 1000 arasında bir değer olmalıdır.");
        }

        // Boolean değer kontrolü için yardımcı metot
        private bool BeValidBoolean(string value)
        {
            return value == "true" || value == "false";
        }

        // URL formatı kontrolü için yardımcı metot
        private bool BeValidUrl(string value)
        {
            Uri uriResult;
            return Uri.TryCreate(value, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
    
}
