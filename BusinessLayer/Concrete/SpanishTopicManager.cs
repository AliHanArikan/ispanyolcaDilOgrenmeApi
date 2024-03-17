using BusinessLayer.Abstract;
using DataAccess.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SpanishTopicManager : ISpanishTopicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISpanishTopicDal _spanishTopicDal;
        public SpanishTopicManager(IUnitOfWork unitOfWork, ISpanishTopicDal spanishTopicDal)
        {
            _unitOfWork = unitOfWork;
            _spanishTopicDal = spanishTopicDal;
        }
        public async Task TAddAsync(SpanishTopic entity)
        {
           _spanishTopicDal.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(SpanishTopic entity)
        {
            if(entity != null)
            {
                _spanishTopicDal.DeleteAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    

        public Task<IEnumerable<SpanishTopic>> TGetAllAsync()
        {
          return _spanishTopicDal.GetAllAsync();
        }

        public Task<SpanishTopic> TGetByIdAsync(int id)
        {
            return _spanishTopicDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(SpanishTopic entity)
        {
            _spanishTopicDal.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
