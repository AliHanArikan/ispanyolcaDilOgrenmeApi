using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ISpanishShortDescriptionDal : IRepository<SpanishShortDescription>
    {
        public Task<IEnumerable<SpanishShortDescription>> GetSpanishShortDescriptionWitLectureId(int id);
    }
}
