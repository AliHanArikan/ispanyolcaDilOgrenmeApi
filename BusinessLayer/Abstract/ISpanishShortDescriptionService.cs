using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISpanishShortDescriptionService : IGenericService<SpanishShortDescription>
    {
        public Task<IEnumerable<SpanishShortDescription>> TGetSpanishShortDescriptionWitTopicId(int id);
    }
}
