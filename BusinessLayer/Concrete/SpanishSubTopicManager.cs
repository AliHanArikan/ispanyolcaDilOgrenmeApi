﻿using BusinessLayer.Abstract;
using DataAccess.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SpanishSubTopicManager : ISpanishSubTopicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISpanishSubTopicDal _spanishSubTopicDal;

        public SpanishSubTopicManager(IUnitOfWork unitOfWork, ISpanishSubTopicDal spanishSubTopicDal)
        {
            _unitOfWork = unitOfWork;
            _spanishSubTopicDal = spanishSubTopicDal;
        }

        public async Task TAddAsync(SpanishSubTopic entity)
        {
           _spanishSubTopicDal.AddAsync(entity);
           await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(SpanishSubTopic entity)
        {
            _spanishSubTopicDal.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task<IEnumerable<SpanishSubTopic>> TGetAllAsync()
        {
          return  _spanishSubTopicDal.GetAllAsync();
        }

        public async Task<SpanishSubTopic> TGetByIdAsync(int id)
        {
            return await _spanishSubTopicDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SpanishSubTopic>> TGetSpanishSubTopicWithSpanishTopicId(int id)
        {
            return await _spanishSubTopicDal.GetSpanishSubTopicWithSpanishTopicId(id);
        }

        public async Task TUpdateAsync(SpanishSubTopic entity)
        {
           _spanishSubTopicDal.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
