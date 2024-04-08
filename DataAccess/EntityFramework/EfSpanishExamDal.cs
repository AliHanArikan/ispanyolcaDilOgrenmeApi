using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfSpanishExamDal : Repository<SpanishExam>, ISpanishExamDal
    {
        public async Task<IEnumerable<SpanishExam>> GetSpanishExamWithLectureId(int id)
        {
            using(Context context = new Context())
            {
                return await context.SpanishExams.Where(x => x.SpanishLectureId == id).ToListAsync();
            }
        }
    }
}
