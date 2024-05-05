using EntityLayer;
using EntityLayer.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISpanishSubTopicService : IGenericService<SpanishSubTopic>
    {
        public Task<IEnumerable<SpanishSubTopic>> TGetSpanishSubTopicWithSpanishTopicId(int id);

        public Task<PagedList<SpanishSubTopic>> TGetAllWithPagination(SpanishSubTopicParameters spanishSubTopicParameters);

    }
}
