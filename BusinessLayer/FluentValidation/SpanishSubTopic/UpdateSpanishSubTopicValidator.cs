﻿using DtoLayer.Dtos.SpanishSubTopicDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation.SpanishSubTopic
{
    public class UpdateSpanishSubTopicValidator : AbstractValidator<UpdateSpanishSubTopicDto>
    {
        public UpdateSpanishSubTopicValidator()
        {
            RuleFor(dto => dto.TopicName)
             .NotEmpty().WithMessage("Alt konu adı boş olamaz.")
             .Length(3, 100).WithMessage("Alt konu adı en az 3 ve en fazla 100 karakter uzunluğunda olmalıdır.")
             .Matches(@"^[a-zA-Z0-9\-_ ]+$").WithMessage("Alt konu adı yalnızca harf, rakam, tire, alt çizgi ve boşluk içerebilir.");

            RuleFor(dto => dto.SubTopicDescription)
                .MaximumLength(1000).WithMessage("Alt konu açıklaması en fazla 1000 karakter olmalıdır.");

            RuleFor(dto => dto.SubTopicDescription2)
                .MaximumLength(1000).WithMessage("İkinci alt konu açıklaması en fazla 1000 karakter olmalıdır.");

            RuleFor(dto => dto.SubTopicPhoto)
                .MaximumLength(100).WithMessage("Alt konu fotoğrafı en fazla 100 karakter olmalıdır.");
                //.Matches(@"^(http|https):\/\/[^\s$.?#].[^\s]*$").When(dto => !string.IsNullOrEmpty(dto.SubTopicPhoto)).WithMessage("Geçerli bir URL formatı girilmelidir.");

            RuleFor(dto => dto.SpanishTopicId)
                .NotEmpty().WithMessage("İspanyolca konu kimliği belirtilmelidir.");

            RuleFor(dto => dto.SpanishSubTopicId)
                .NotEmpty().WithMessage("İspanyolca alt konu kimliği belirtilmelidir.");

        }
    }
}
