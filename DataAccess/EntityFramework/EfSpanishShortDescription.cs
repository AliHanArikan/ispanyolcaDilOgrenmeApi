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
    public class EfSpanishShortDescription : Repository<SpanishShortDescription>, ISpanishShortDescriptionDal
    {
        public async Task<IEnumerable<SpanishShortDescription>> GetSpanishShortDescriptionWitLectureId(int id)
        {
           using(Context context = new Context())
            {
                return await context.SpanishShortDescriptions.Where(x => x.SpanishLectureId == id).ToListAsync();
            }
        }
    }
}
