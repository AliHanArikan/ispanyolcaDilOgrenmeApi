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
    public class SpanishShortDescriptionManager : ISpanishShortDescriptionService
    {

        private readonly ISpanishShortDescriptionDal _spanishShortDescriptionDal;
        private readonly IUnitOfWork _unitOfWork;

        public SpanishShortDescriptionManager(ISpanishShortDescriptionDal spanishShortDescriptionDal, IUnitOfWork unitOfWork)
        {
            _spanishShortDescriptionDal = spanishShortDescriptionDal;
            _unitOfWork = unitOfWork;
        }

        public async Task TAddAsync(SpanishShortDescription entity)
        {
            await _spanishShortDescriptionDal.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(SpanishShortDescription entity)
        {
            await _spanishShortDescriptionDal.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task<IEnumerable<SpanishShortDescription>> TGetAllAsync()
        {
            return _spanishShortDescriptionDal.GetAllAsync();
        }

        public Task<SpanishShortDescription> TGetByIdAsync(int id)
        {
            return _spanishShortDescriptionDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(SpanishShortDescription entity)
        {
            await _spanishShortDescriptionDal.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
