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
    public class SpanishExamManager : ISpanishExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISpanishExamDal _spanishExamDal;

        public SpanishExamManager(IUnitOfWork unitOfWork, ISpanishExamDal spanishExamDal)
        {
            _unitOfWork = unitOfWork;
            _spanishExamDal = spanishExamDal;
        }


        public async Task TAddAsync(SpanishExam entity)
        {
            _spanishExamDal.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(SpanishExam entity)
        {
           _spanishExamDal.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task<IEnumerable<SpanishExam>> TGetAllAsync()
        {
            return _spanishExamDal.GetAllAsync();

        }

        public Task<SpanishExam> TGetByIdAsync(int id)
        {
            return _spanishExamDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SpanishExam>> TGetSpanishExamWithLectureId(int id)
        {
            return await _spanishExamDal.GetSpanishExamWithLectureId(id);
        }

        public async Task TUpdateAsync(SpanishExam entity)
        {
            await _spanishExamDal.UpdateAsync(entity);
            _unitOfWork.SaveChangesAsync();
        }
    }
}
