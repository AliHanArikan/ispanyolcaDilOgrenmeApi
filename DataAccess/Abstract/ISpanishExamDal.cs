using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ISpanishExamDal : IRepository<SpanishExam>
    {
        public Task<IEnumerable<SpanishExam>> GetSpanishExamWithLectureId(int id);
    }
}
