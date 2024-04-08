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
    public class SpanishLectureManager : ISpanishLectureService
    {
        private readonly ISpanishLectureDal _spanishLectureDal;
        private readonly IUnitOfWork _unitOfWork;

        public SpanishLectureManager(ISpanishLectureDal spanishLectureDal, IUnitOfWork unitOfWork)
        {
            _spanishLectureDal = spanishLectureDal;
            _unitOfWork = unitOfWork;
        }

        public async Task TAddAsync(SpanishLecture entity)
        {
           await _spanishLectureDal.AddAsync(entity);
           await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(SpanishLecture entity)
        {
            await _spanishLectureDal.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<SpanishLecture>> TGetAllAsync()
        {
            var values = await _spanishLectureDal.GetAllAsync();
            return values;
        }

        public async Task<SpanishLecture> TGetByIdAsync(int id)
        {
            return await _spanishLectureDal.GetByIdAsync(id);
           
        }

        public async Task TUpdateAsync(SpanishLecture entity)
        {
            await _spanishLectureDal.UpdateAsync(entity);
             await _unitOfWork.SaveChangesAsync();
        }
    }
}
